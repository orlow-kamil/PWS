using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingTesting : MonoBehaviour
{
    private Pathfinding pathfinding;

    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);    
    }
}
