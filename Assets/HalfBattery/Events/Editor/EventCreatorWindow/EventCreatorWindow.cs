using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.EditorGUI;


public class EventCreatorWindow : EditorWindow
{
    [MenuItem("Window/HalfBattery/Event Creator")]
    public static void ShowWindow()
    {
       EditorWindow.GetWindow(typeof(EventCreatorWindow));
    }

    private const string eventTemplatePath = "Assets/HalfBattery/Events/Editor/EventCreatorWindow/Templates/event.template";
    private const string eventListenerTemplatePath = "Assets/HalfBattery/Events/Editor/EventCreatorWindow/Templates/eventListener.template";
    private const string defaultSavePath = "Assets/HalfBattery/Events/Generated";

    private string eventTemplate;
    private string eventListenerTemplate;

    private string eventName = "";
    private string @namespace = "HalfBattery.Events";
    private string usings = "";
    private string types = "";
    private string createAssetPath = "HalfBattery/Events";

    private string generatedEvent;
    private string generatedEventListener;

    private Vector2 scroll;
    private bool edit;

    void Awake()
    {
        using (var eventReader = new StreamReader(eventTemplatePath))
        using (var eventListenerReader = new StreamReader(eventListenerTemplatePath))
        {
            eventTemplate = eventReader.ReadToEnd();
            eventListenerTemplate = eventListenerReader.ReadToEnd();
        }

        GenerateEvent();
    }

    void OnGUI()
    {
        BeginChangeCheck();

        eventName = TextField("Name", eventName);
        usings = TextField("Usings", usings);
        @namespace = TextField("Namespace", @namespace);
        types = TextField("Types", types);
        createAssetPath = TextField("Create asset path", createAssetPath);

        var change = EditorGUI.EndChangeCheck();

        if (change)
        {
            GenerateEvent();
        }

        edit = Toggle("Edit", edit);

        if (edit)
        {
            scroll = BeginScrollView(scroll);
            PrefixLabel("Event:");
            TextArea(generatedEvent, GUI.skin.textField);
            PrefixLabel("Event Listener:");
            TextArea(generatedEventListener, GUI.skin.textField);
            EndScrollView();
        }

        if (GUILayout.Button("Save"))
        {
            var path = EditorUtility.OpenFolderPanel("Select a location to save", defaultSavePath, "");

            if (path == "") return;

            using (var eventWriter = new StreamWriter(path + "/" + eventName + "EventReference.cs"))
            using (var eventListenerWriter = new StreamWriter(path + "/" + eventName + "EventListener.cs"))
            {
                eventWriter.Write(generatedEvent);
                eventListenerWriter.Write(generatedEventListener);
            }
            AssetDatabase.Refresh();
        }

    }

    private void GenerateEvent()
    {
        var usingFixed = usings.Split(',')
                        .Select(s => s.Replace(" ", ""))
                        .Where(s => s.Length > 0)
                        .Select(s => "using " + s + ";\n")
                        .Aggregate("", (acc, s) => acc + s);

        var typesSplited = types.Split(',')
                        .Select(s => s.Replace(" ", ""))
                        .Where(s => s.Length > 0)
                        .Take(4);

        var typesFixed = typesSplited
                        .Select(s => s + ", ")
                        .Aggregate("", (acc, s) => acc + s)
                        .RemoveLast(", ");

        var raiseParameters = typesSplited
                              .Zip(new string[] { "1", "2", "3", "4" }, (t, n) => t + " value" + n + ", ")
                              .Aggregate("", (acc, s) => acc + s)
                              .RemoveLast(", ");

        var raiseValues = typesSplited
                         .Zip(new string[] { "1", "2", "3", "4" }, (t, n) => " value" + n + ", ")
                         .Aggregate("", (acc, s) => acc + s)
                         .RemoveLast(", ");

        var eventNameFixed = eventName.Replace(" ", "");
        var namesFixed = @namespace.Replace(" ", "");
        var assetPathFixed = createAssetPath.Replace(" ", "") + "/" + eventNameFixed;

        generatedEvent = eventTemplate
                        .Replace("{eventName}", eventNameFixed)
                        .Replace("{namespace}", namesFixed)
                        .Replace("{assetPath}", assetPathFixed)
                        .Replace("{using}", usingFixed)
                        .Replace("{types}", typesFixed)
                        .Replace("{raiseParameters}", raiseParameters)
                        .Replace("{raiseValues}", raiseValues);

        generatedEventListener = eventListenerTemplate
                                .Replace("{eventName}", eventNameFixed)
                                .Replace("{namespace}", namesFixed);
        
    }

}

