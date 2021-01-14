using Extra;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingTesting : MonoBehaviour
{
    [SerializeField] private Transform background = null;
    [SerializeField] private GameObject character = null;

    private Pathfinding pathfinding;
    private TileMesh obstacle;
    private CharacterPathfindingMovementHandler characterPathfinding;

    private void Awake()
    {
        obstacle = GetComponent<TileMesh>();

        if (background is null)
            throw new System.ArgumentException("Background is missing");

        if (character is null)
            throw new System.ArgumentException("Prefab character is missing");
    }

    private void Start()
    {
        characterPathfinding = Instantiate(character).GetComponent<CharacterPathfindingMovementHandler>();
        pathfinding = new Pathfinding(10, 10);
        characterPathfinding.SetStartPosition();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = UtilitsClass.GetMouseWorldPosition(background.position.z);
            pathfinding.GetGrid().GetXY(characterPathfinding.GetPosition(), out int startX, out int startY);
            pathfinding.GetGrid().GetXY(mouseWorldPos, out int endX, out int endY);
            List<PathNode> path = pathfinding.FindPath(startX, startY, endX, endY);
            if (path != null)
            {
                Debug.Log("Path exist");
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 2.5f);
                }
            }
            characterPathfinding.SetTargetPosition(mouseWorldPos);
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
