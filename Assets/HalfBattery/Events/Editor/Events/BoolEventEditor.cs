using UnityEditor;
using UnityEngine;

namespace HalfBattery.Events.Editor
{
    [CustomEditor(typeof(BoolEventReference))]
    public class BoolEventReferenceEditor : UnityEditor.Editor
    {
        bool value;

        public override void OnInspectorGUI()
        {
            var e = target as BoolEventReference;

            EditorGUILayout.LabelField("Description:");
            e.description = EditorGUILayout.TextArea(e.description);

            value = EditorGUILayout.Toggle("Bool value", value);

            GUI.enabled = Application.isPlaying;
            if (GUILayout.Button("Raise"))
            {
                e.Raise(value);
            }
        }
    }
}