using UnityEditor;
using UnityEngine;

namespace HalfBattery.Events.Editor
{
    [CustomEditor(typeof(EventReference))]
    public class EventReferenceEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            if (GUILayout.Button("Raise"))
            {
                var e = target as EventReference;
                e.Raise();
            }
        }
    }
}