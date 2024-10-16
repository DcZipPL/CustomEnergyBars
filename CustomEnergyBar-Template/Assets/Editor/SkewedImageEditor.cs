﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace CustomEnergyBar
{
	[CustomEditor(typeof(SkewedImage))]
	public class SkewedImageEditor : UnityEditor.UI.ImageEditor
	{
		SerializedProperty skewX;
		SerializedProperty skewY;

		protected override void OnEnable() {
			base.OnEnable();

			skewX = serializedObject.FindProperty("skewX");
			skewY = serializedObject.FindProperty("skewY");
		}

		public override void OnInspectorGUI() {
			SkewedImage skewedImage = (SkewedImage)target;

			serializedObject.Update();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Skew");
			float prevWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = 13;
			skewX.floatValue = EditorGUILayout.FloatField("X", skewX.floatValue);
			skewY.floatValue = EditorGUILayout.FloatField("Y", skewY.floatValue);
			EditorGUIUtility.labelWidth = prevWidth;
			EditorGUILayout.EndHorizontal();

			serializedObject.ApplyModifiedProperties();

			base.OnInspectorGUI();
		}
	}
}