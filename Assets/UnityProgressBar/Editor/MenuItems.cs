using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityProgressBar.Editor
{
    static class MenuItems
    {
        [MenuItem("GameObject/UI/Progress Bar/Progress Bar - Fill")]
        public static void CreateFillProgressBar()
        {
            var path = "Packages/com.annulusgames.ugui-progress-bar/Editor/DefaultAssets/Progress Bar - Fill.prefab";
            CreateUIItem(path, "Progress Bar");
        }

        [MenuItem("GameObject/UI/Progress Bar/Circular Progress Bar")]
        public static void CreateCircularFillProgressBar()
        {
            var path = "Packages/com.annulusgames.ugui-progress-bar/Editor/DefaultAssets/Circular Progress Bar.prefab";
            CreateUIItem(path, "Circular Progress Bar");
        }

        [MenuItem("GameObject/UI/Progress Bar/Progress Bar - Streach")]
        public static void CreateStreachProgressBar()
        {
            var path = "Packages/com.annulusgames.ugui-progress-bar/Editor/DefaultAssets/Progress Bar - Streach.prefab";
            CreateUIItem(path, "Progress Bar");
        }

        static void CreateUIItem(string assetPath, string objectName)
        {
            var obj = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(assetPath));

            var canvas = Object.FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                canvas = new GameObject("Canvas").AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.gameObject.AddComponent<CanvasScaler>();
                canvas.gameObject.AddComponent<GraphicRaycaster>();

                if (Object.FindObjectOfType<EventSystem>() == null)
                {
                    _ = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
                }
            }

            obj.name = objectName;
            obj.transform.SetParent(canvas.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            Undo.RegisterCreatedObjectUndo(obj, "Create " + objectName);
            Selection.activeGameObject = obj;
        }
    }
}