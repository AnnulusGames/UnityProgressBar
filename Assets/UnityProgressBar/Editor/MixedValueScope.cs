using System;
using UnityEditor;

namespace UnityProgressBar.Editor
{
    public struct MixedValueScope : IDisposable
    {
        bool isDisposed;
        bool prevMixedValue;

        public MixedValueScope(bool showMixedValue)
        {
            isDisposed = false;
            prevMixedValue = EditorGUI.showMixedValue;
            EditorGUI.showMixedValue = showMixedValue;
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                EditorGUI.showMixedValue = prevMixedValue;
            }
        }
    }
}
