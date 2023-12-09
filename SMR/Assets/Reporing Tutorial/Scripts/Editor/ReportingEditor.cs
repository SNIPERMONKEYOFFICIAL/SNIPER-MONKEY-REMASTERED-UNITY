using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ReportingSystem;

[CustomEditor(typeof(Reporting))]

public class ReportingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Reporting reporting = (Reporting)target;
        
        if (reporting.Type == Reporting.Keys.PlayerSelectButton)
        {
            EditorGUILayout.LabelField("Start At 1");
            reporting.PlayerSpot = EditorGUILayout.IntField("Report Spot", reporting.PlayerSpot);
        }
        EditorGUILayout.Space(10);
        reporting.Type = (Reporting.Keys)EditorGUILayout.EnumPopup(reporting.Type);
        EditorGUILayout.Space(5);


        EditorGUILayout.LabelField("Must Watch!");
        if (GUILayout.Button("Tutorial", GUILayout.Width(60)))
        {
            Application.OpenURL("https://youtu.be/_yRVASzG5Hk");
        }
    }
}
