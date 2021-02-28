using UnityEditor;

[CustomEditor(typeof(IDButton))]
public class IDButtonEditor : UnityEditor.UI.ButtonEditor
{
    private SerializedProperty _onSelect;
    private SerializedProperty _transitionTargets;
    
    protected override void OnEnable()
    {
        base.OnEnable();

        _transitionTargets = serializedObject.FindProperty("transitionTargets");
        _onSelect = serializedObject.FindProperty("onSelect");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.Space();
        //EditorGUILayout.PropertyField(_onSelect);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(_transitionTargets);

        serializedObject.ApplyModifiedProperties();
    }
}
