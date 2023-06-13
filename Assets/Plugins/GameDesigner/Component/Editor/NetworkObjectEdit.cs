#if (UNITY_STANDALONE || UNITY_ANDROID || UNITY_IOS || UNITY_WSA || UNITY_WEBGL) && UNITY_EDITOR
using Net.UnityComponent;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NetworkObject))]
[CanEditMultipleObjects]
public class NetworkObjectEdit : Editor
{
    private NetworkObject no;
    private Vector2 scrollPosition;

    private void OnEnable()
    {
        no = target as NetworkObject;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUI.enabled = false;
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        foreach (var item in no.syncVarInfos.Values)
        {
            if (item.IsDispose)
            {
                GUI.color = Color.gray;
                EditorGUILayout.LabelField(item.ToString());
            }
            else
            {
                GUI.color = Color.green;
                EditorGUILayout.LabelField(item.ToString());
            }
        }
        EditorGUILayout.EndScrollView();
        GUI.color = Color.yellow;
        EditorGUILayout.LabelField("Network Identity", no.Identity.ToString());
        GUI.enabled = true;
    }
}
#endif