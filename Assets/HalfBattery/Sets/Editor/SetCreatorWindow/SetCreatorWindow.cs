using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.EditorGUI;


public class SetCreatorWindow : EditorWindow
{
    [MenuItem("Window/HalfBattery/Set Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SetCreatorWindow));
    }

    private const string setTemplatePath = "Assets/HalfBattery/Sets/Editor/SetCreatorWindow/Templates/set.template";
    private const string defaultSavePath = "Assets/HalfBattery/Sets/Generated";

    private string setTemplate;

    private string setName = "";
    private string @namespace = "HalfBattery.Sets";
    private string usings = "";
    private string type = "";
    private string createAssetPath = "HalfBattery/Sets";

    private string generatedSet;

    private Vector2 scroll;
    private bool edit;

    void Awake()
    {
        using (var setReader = new StreamReader(setTemplatePath))
        {
            setTemplate = setReader.ReadToEnd();
        }

        GenerateSet();
    }

    void OnGUI()
    {
        BeginChangeCheck();

        setName = TextField("Name", setName);
        usings = TextField("Usings", usings);
        @namespace = TextField("Namespace", @namespace);
        type = TextField("Type", type);
        createAssetPath = TextField("Create asset path", createAssetPath);

        var change = EditorGUI.EndChangeCheck();

        if (change)
        {
            GenerateSet();
        }

        edit = Toggle("Edit", edit);

        if (edit)
        {
            scroll = BeginScrollView(scroll);
            PrefixLabel("Set:");
            TextArea(generatedSet, GUI.skin.textField);
            EndScrollView();
        }

        if (GUILayout.Button("Save"))
        {
            var path = EditorUtility.OpenFolderPanel("Select a location to save", defaultSavePath, "");

            if (path == "") return;

            using (var setWriter = new StreamWriter(path + "/" + setName + "Set.cs"))
            {
                setWriter.Write(generatedSet);
            }
            AssetDatabase.Refresh();
        }

    }

    private void GenerateSet()
    {
        var usingFixed = usings.Split(',')
                        .Select(s => s.Replace(" ", ""))
                        .Where(s => s.Length > 0)
                        .Select(s => "using " + s + ";\n")
                        .Aggregate("", (acc, s) => acc + s);
        
        var typeFixed = type.Replace(" ", "");
        var nameFixed = setName.Replace(" ", "");
        var namesFixed = @namespace.Replace(" ", "");
        var assetPathFixed = createAssetPath.Replace(" ", "") + "/" + nameFixed;

        generatedSet = setTemplate
                        .Replace("{name}", nameFixed)
                        .Replace("{namespace}", namesFixed)
                        .Replace("{assetPath}", assetPathFixed)
                        .Replace("{usings}", usingFixed)
                        .Replace("{type}", typeFixed);
    }

}
