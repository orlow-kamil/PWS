using Extra;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingTesting : MonoBehaviour
{
    [SerializeField] private Transform background = null;
    private Pathfinding pathfinding;

    private TileMesh obstacle;

    private void Awake()
    {
        obstacle = GetComponent<TileMesh>();
    }

    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);    
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = UtilitsClass.GetMouseWorldPosition(background.position.z);
            pathfinding.GetGrid().GetXY(mouseWorldPos, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                Debug.Log("Path exist");
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 2.5f);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPos = UtilitsClass.GetMouseWorldPosition(background.position.z);
            pathfinding.GetGrid().GetXY(mouseWorldPos, out int x, out int y);
            PathNode pathNode = pathfinding.GetGrid().GetGridObject(x, y);
            if (pathNode != default && pathNode.isWalkable)
                obstacle.CreateObstacle(pathfinding, mouseWorldPos);
        }
    }
}
