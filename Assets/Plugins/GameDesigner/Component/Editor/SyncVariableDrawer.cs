#if (UNITY_STANDALONE || UNITY_ANDROID || UNITY_IOS || UNITY_WSA || UNITY_WEBGL) && UNITY_EDITOR
using Net.Share;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SyncVariable<>))]
public class SyncVariableDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var valueProperty = property.FindPropertyRelative("value");
        EditorGUI.PropertyField(position, valueProperty, label, true);
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<byte>))]
public class SyncVariableByteDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<byte>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = (byte)EditorGUI.IntField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<sbyte>))]
public class SyncVariableSByteDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<sbyte>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = (sbyte)EditorGUI.IntField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<short>))]
public class SyncVariableShortDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<short>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = (short)EditorGUI.IntField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<ushort>))]
public class SyncVariableUShortDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<ushort>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = (ushort)EditorGUI.IntField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<char>))]
public class SyncVariableCharDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<char>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = (char)EditorGUI.IntField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<int>))]
public class SyncVariableIntDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<int>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.IntField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<uint>))]
public class SyncVariableUIntDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<uint>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = (uint)EditorGUI.IntField(position, label, (int)syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<float>))]
public class SyncVariableFloatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<float>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.FloatField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<long>))]
public class SyncVariableLongDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<long>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.LongField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<ulong>))]
public class SyncVariableULongDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<ulong>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = (ulong)EditorGUI.LongField(position, label, (long)syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<double>))]
public class SyncVariableDoubleDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<double>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.DoubleField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<string>))]
public class SyncVariableStringDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<string>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.TextField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<Vector2>))]
public class SyncVariableVector2Drawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<Vector2>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.Vector2Field(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<Vector3>))]
public class SyncVariableVector3Drawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<Vector3>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.Vector3Field(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<Vector4>))]
public class SyncVariableVector4Drawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<Vector4>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.Vector4Field(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<Quaternion>))]
public class SyncVariableQuaternionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<Quaternion>;
        EditorGUI.BeginChangeCheck();
        var quaternion = syncVariable.Value;
        var vector4 = EditorGUI.Vector4Field(position, label, new Vector4(quaternion.x, quaternion.y, quaternion.z, quaternion.w));
        syncVariable.Value = new Quaternion(vector4.x, vector4.y, vector4.z, vector4.w);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(SyncVariable<Rect>))]
public class SyncVariableRectDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var syncVariable = fieldInfo.GetValue(property.serializedObject.targetObject) as SyncVariable<Rect>;
        EditorGUI.BeginChangeCheck();
        syncVariable.Value = EditorGUI.RectField(position, label, syncVariable.Value);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        EditorGUI.EndProperty();
    }
}
#endif