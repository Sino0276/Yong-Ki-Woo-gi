using UnityEditor;
using UnityEngine;

// Draw StatValue<T> on a single line (no foldout) by rendering the private serialized field "value".
// Works for any closed generic like StatValue<int>, StatValue<float>, etc.
[CustomPropertyDrawer(typeof(StatValue<>), true)]
public class StatValueDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty valueProp = property.FindPropertyRelative("value");

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, label);
        int prevIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        if (valueProp != null)
            EditorGUI.PropertyField(position, valueProp, GUIContent.none);
        else
            EditorGUI.LabelField(position, "Missing field: value");

        EditorGUI.indentLevel = prevIndent;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        => EditorGUIUtility.singleLineHeight;
}

