using BeatThat.Properties;
using UnityEditor;

namespace BeatThat
{
	[CustomEditor(typeof(RangeDrivesInt), true)]
	[CanEditMultipleObjects]
	public class RangeDrivesIntEditor : DisplaysFloatEditor
	{

		override protected void OnDisplaysFloatInspectorGUI() 
		{
			DrawDisplaysFloatProperties();

			var drivenProp = this.serializedObject.FindProperty("m_driven");

			var fromValProp = this.serializedObject.FindProperty("m_from");
			var fromProp = this.serializedObject.FindProperty("m_fromProp");
			var useFromProp = this.serializedObject.FindProperty("m_useFromProp");


			var toValProp = this.serializedObject.FindProperty("m_to");
			var toProp = this.serializedObject.FindProperty("m_toProp");
			var useToProp = this.serializedObject.FindProperty("m_useToProp");

			EditorGUILayout.PropertyField(drivenProp);

			EditorGUILayout.PropertyField(useFromProp);
			if(useFromProp.boolValue) {
				EditorGUILayout.PropertyField(fromProp);
			}
			else {
				EditorGUILayout.PropertyField(fromValProp);
			}

			EditorGUILayout.PropertyField(useToProp);
			if(useToProp.boolValue) {
				EditorGUILayout.PropertyField(toProp);
			}
			else {
				EditorGUILayout.PropertyField(toValProp);
			}

			this.serializedObject.ApplyModifiedProperties();
		}
	}
}
