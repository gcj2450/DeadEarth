using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointNetwork))]
//[CanEditMultipleObjects]
public class WaypointNetworkEditor : Editor
{
    public void OnSceneGUI()
    {
        WaypointNetwork network = (WaypointNetwork)target;

        for (int i = 0; i < network.Waypoints.Count; i++)
        {
            Debug.Log("in here");
            
            if (network.Waypoints[i] != null)
                Handles.Label(network.Waypoints[i].position, "Waypoint ALUU " + i.ToString() );
        }
        Vector3[] linePoints = new Vector3[network.Waypoints.Count + 1];

        for(int i = 0; i <= network.Waypoints.Count; i++)
        {
            int index = i != network.Waypoints.Count ? i : 0;

            if (network.Waypoints[index] != null)
                linePoints[i] = network.Waypoints[index].position;
            else
                linePoints[i] = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
        }

        Handles.color = Color.white;
        Handles.DrawPolyLine(linePoints);
        


        Debug.Log("in here2");

        /*
                    var t = (target as LookAtPoint);

                EditorGUI.BeginChangeCheck();
                Vector3 pos = Handles.PositionHandle(t.lookAtPoint, Quaternion.identity);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "Move point");
                    t.lookAtPoint = pos;
                    t.Update();
                }*/
    }
}
