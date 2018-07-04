using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.EditorGUI;

public class VariableCreatorWindow : EditorWindow
{
    [MenuItem("Window/HalfBattery/Variable Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(VariableCreatorWindow));
    }

    private const string variableTemplatePath = "Assets/HalfBattery/Variables/Editor/VariableCreatorWindow/Templates/variable.template";
    private const string variableReferenceTemplatePath = "Assets/HalfBattery/Variables/Editor/VariableCreatorWindow/Templates/variableDrawer.template";
    private const string defaultSavePath = "Assets/HalfBattery/Variables/Generated";

    private string variableTemplate;
    private string variableReferenceTemplate;

    private string variableName = "";
    private string @namespace = "HalfBattery.Variables";
    private string usings = "";
    private string type = "";
    private string createAssetPath = "HalfBattery/Variables";

    private string generatedVariable;
    private string generatedVariableReferenceDrawer;

    private Vector2 scroll;
    private bool edit;

    void Awake()
    {
        using (var variableReader = new StreamReader(variableTemplatePath))
        using (var variableReferenceDrawerReader = new StreamReader(variableReferenceTemplatePath))
        {
            variableTemplate = variableReader.ReadToEnd();
            variableReferenceTemplate = variableReferenceDrawerReader.ReadToEnd();
        }

        GenerateVariable();
    }

    void OnGUI()
    {
        BeginChangeCheck();

        variableName = TextField("Name", variableName);
        usings = TextField("Usings", usings);
        @namespace = TextField("Namespace", @namespace);
        type = TextField("Type", type);
        createAssetPath = TextField("Create asset path", createAssetPath);

        var change = EditorGUI.EndChangeCheck();

        if (change)
        {
            GenerateVariable();
        }

        edit = Toggle("Edit", edit);

        if (edit)
        {
            scroll = BeginScrollView(scroll);
            PrefixLabel("Variable:");
            TextArea(generatedVariable, GUI.skin.textField);
            PrefixLabel("Variable Reference Drawer:");
            TextArea(generatedVariableReferenceDrawer, GUI.skin.textField);
            EndScrollView();
        }

        if (GUILayout.Button("Save"))
        {
            var path = EditorUtility.OpenFolderPanel("Select a location to save", defaultSavePath, "");

            if (path == "") return;

            using (var variableWriter = new StreamWriter(path + "/" + variableName + "Variable.cs"))
            using (var variableReferenceWriter = new StreamWriter(path + "/Editor/" + variableName + "ReferenceDrawer.cs"))
            {
                variableWriter.Write(generatedVariable);
                variableReferenceWriter.Write(generatedVariableReferenceDrawer);
            }
            AssetDatabase.Refresh();
        }


    }

    private void GenerateVariable()
    {
        var usingFixed = usings.Split(',')
                        .Select(s => s.Replace(" ", ""))
                        .Where(s => s.Length > 0)
                        .Select(s => "using " + s + ";\n")
                        .Aggregate("", (acc, s) => acc + s);

        var typeFixed = type.Replace(" ", "");
        var variableNameFixed = variableName.Replace(" ", "");
        var namesFixed = @namespace.Replace(" ", "");
        var assetPathFixed = createAssetPath.Replace(" ", "") + "/" + variableNameFixed;

        generatedVariable = variableTemplate
                        .Replace("{name}", variableNameFixed)
                        .Replace("{namespace}", namesFixed)
                        .Replace("{assetPath}", assetPathFixed)
                        .Replace("{usings}", usingFixed)
                        .Replace("{type}", typeFixed);

        generatedVariableReferenceDrawer = variableReferenceTemplate
                                .Replace("{name}", variableNameFixed)
                                .Replace("{usings}", usingFixed)
                                .Replace("{namespace}", namesFixed)
                                .Replace("{type}", typeFixed);

    }

}

