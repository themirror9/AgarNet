using UnityEditor;
using UnityEngine;

public class GetPathWindow : EditorWindow
{
    [MenuItem("Window/HalfBattery/Utils/Get Path")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GetPathWindow));
    }

    private Object item;
    private string path;

    void OnGUI()
    {
        item = EditorGUILayout.ObjectField("Item", item, typeof(Object), false);
        if (item != null)
        {
            EditorGUILayout.PrefixLabel("Path");
            GUI.enabled = false;
            path = AssetDatabase.GetAssetPath(item);
            EditorGUILayout.TextArea(path);
        }

        GUI.enabled = item != null;
        if (GUILayout.Button("Copy path"))
        {
            EditorGUIUtility.systemCopyBuffer = path.Replace(" ", "");
        }
    }

    [MenuItem("Assets/Copy path")]
    public static void CopyPath()
    {
        EditorGUIUtility.systemCopyBuffer = AssetDatabase.GetAssetPath(Selection.activeObject);
    }


}
