using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class PathEnemy : MonoBehaviour
{
    [SerializeField] bool alwayDrawPath;
    [SerializeField] bool drawAsLoop;
    [SerializeField] bool drawNUmbers;
    public Color debugColor = Color.white;

    public List<Transform>  _waypoints = new List<Transform>();

    public void OnDrawGizmos()
    {
        if(alwayDrawPath)
        {
            DrawPath();
        }
    }
    public void DrawPath()
    {
#if UNITY_EDITOR
        //for (int i = 0; i < _waypoints.Count; i++)
        //{
        //    GUIStyle labelStyle = new GUIStyle();
        //    labelStyle.fontSize = 30;
        //    labelStyle.normal.textColor = debugColor;
        //    if(drawNUmbers)
        //    {
        //       Handles.Label(_waypoints[i].position, i.ToString(), labelStyle);

        //        if(i>= 1)
        //        {
        //            Gizmos.color = debugColor;
        //            Gizmos.DrawLine(_waypoints[i - 1].position, _waypoints[i].position);
        //            if(drawAsLoop)
        //            {
        //                Gizmos.DrawLine(_waypoints[_waypoints.Count - 1].position, _waypoints[0].position);

        //            }
        //        }


        //    }

        //}
#endif
    }
    public void OnDrawGizmosSelected()
    {
        if (alwayDrawPath)
            return;
        else
            DrawPath();
    }
}
