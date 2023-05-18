using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake() {
        points = new Transform[Transform.childCount];

        for (int i = 0; i < points.Length; i++)
            points[i] = Transform.GetChild(i);
    }
}
