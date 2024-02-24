using System.Linq;
using UnityEditor;

namespace UnityProgressBar.Editor
{
    public abstract class ProgressBarEditorBase : UnityEditor.Editor
    {
        const string UndoMessage_MinValue = "Change ProgressBar Min Value";
        const string UndoMessage_MaxValue = "Change ProgressBar Max Value";
        const string UndoMessage_Value = "Change ProgressBar Value";

        void OnEnable()
        {
            Notify();
            Undo.undoRedoEvent += OnUndo;
        }

        void OnDisable()
        {
            Undo.undoRedoEvent -= OnUndo;
        }

        void OnUndo(in UndoRedoInfo info)
        {
            if (info.undoName is UndoMessage_MinValue or UndoMessage_MaxValue or UndoMessage_Value)
            {
                Notify();
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawValueFields();
            EditorGUILayout.Space();
            DrawOnValueChangedEvent();

            serializedObject.ApplyModifiedProperties();
        }

        protected void DrawOnValueChangedEvent()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onValueChanged"));
        }

        protected void DrawValueFields()
        {
            var minValueProperty = serializedObject.FindProperty("minValue");
            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                using (new MixedValueScope(minValueProperty.hasMultipleDifferentValues))
                {
                    var fieldValue = EditorGUILayout.DelayedFloatField("Min Value", minValueProperty.floatValue);
                    if (changeCheck.changed)
                    {
                        Undo.RecordObjects(targets, UndoMessage_MinValue);
                        foreach (var target in targets.Select(x => (ProgressBarBase)x))
                        {
                            if (fieldValue <= target.MaxValue) target.MinValue = fieldValue;
                        }
                    }
                }
            }

            var maxValueProperty = serializedObject.FindProperty("maxValue");
            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                using (new MixedValueScope(maxValueProperty.hasMultipleDifferentValues))
                {
                    var fieldValue = EditorGUILayout.DelayedFloatField("Max Value", maxValueProperty.floatValue);
                    if (changeCheck.changed)
                    {
                        Undo.RecordObjects(targets, UndoMessage_MaxValue);
                        foreach (var target in targets.Select(x => (ProgressBarBase)x))
                        {
                            if (fieldValue >= target.MinValue) target.MaxValue = fieldValue;
                        }
                    }
                }
            }

            var valueProperty = serializedObject.FindProperty("value");
            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                using (new MixedValueScope(valueProperty.hasMultipleDifferentValues))
                {
                    var fieldValue = EditorGUILayout.Slider("Value", valueProperty.floatValue, minValueProperty.floatValue, maxValueProperty.floatValue);
                    if (changeCheck.changed)
                    {
                        Undo.RecordObjects(targets, UndoMessage_Value);
                        foreach (var target in targets.Select(x => (ProgressBarBase)x))
                        {
                            target.Value = fieldValue;
                        }
                    }
                }
            }
        }

        void Notify()
        {
            foreach (var target in targets.Select(x => (ProgressBarBase)x))
            {
                target.ForceNotify();
            }
        }
    }
}
