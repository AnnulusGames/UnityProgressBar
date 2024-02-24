using UnityEditor;

namespace UnityProgressBar.Editor
{
    [CustomEditor(typeof(ProgressBar))]
    [CanEditMultipleObjects]
    public sealed class ProgressBarEditor : ProgressBarEditorBase
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawValueFields();

            EditorGUILayout.Space();

            var fillModeProperty = serializedObject.FindProperty("fillMode");
            EditorGUILayout.PropertyField(fillModeProperty);
            if (fillModeProperty.enumValueIndex == 0)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("fillImage"));
            }
            else
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("fillRect"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("direction"));
            }

            EditorGUILayout.Space();

            DrawOnValueChangedEvent();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
