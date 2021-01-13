using UnityEngine;

namespace Extra
{
    public static class UtilitsClass
    {
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, Color color, int fontSize, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 5000)
        {
            GameObject gameObject = new GameObject($"World_Text {text}", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;

            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }

        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default, Color? color = null, int fontSize = 40, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 5000)
        {
            if (color == null) color = Color.white;
            return CreateWorldText(parent, text, localPosition, (Color)color, fontSize, textAnchor, textAlignment, sortingOrder);
        }

        public static Vector3 GetMouseWorldPosition(float groundZ)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = groundZ - Camera.main.transform.position.z;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}