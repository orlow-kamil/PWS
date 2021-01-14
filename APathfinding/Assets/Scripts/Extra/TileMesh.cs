using UnityEngine;

public class TileMesh : MonoBehaviour
{
    [SerializeField] private Material obstacleMaterial = null;
    [SerializeField] private Transform parent = null;

    private void Awake()
    {
        if (obstacleMaterial is null)
            throw new System.ArgumentNullException("Obstacle material is empty");
        if (parent is null)
            throw new System.ArgumentNullException("PArent is empty");
    }

    public void CreateObstacle(Pathfinding pathfinding, Vector3 mouseWorldPos)
    {
        PathNode pathNode = GetPathNode(pathfinding, mouseWorldPos, out Vector3 pathNodeWorldPos);
        float titleSize = pathfinding.GetGrid().GetCellSize();
        Mesh mesh = CreateTileMesh(pathNode, titleSize);
        string name = CreateTileMeshName(pathNode);

        CreateObstacle(name, mesh);
    }

    private void CreateObstacle(string name, Mesh mesh)
    {
        GameObject obstacle = new GameObject(name, typeof(MeshFilter), typeof(MeshRenderer));
        obstacle.transform.SetParent(parent);

        obstacle.GetComponent<MeshFilter>().mesh = mesh;
        obstacle.GetComponent<MeshRenderer>().material = obstacleMaterial;
    }

    private string CreateTileMeshName(PathNode pathNode) => $"Obstacle {pathNode.x}, {pathNode.y}";

    private PathNode GetPathNode(Pathfinding pathfinding, Vector3 mouseWorldPos, out Vector3 pathNodeWorldPos)
    {
        pathfinding.GetGrid().GetXY(mouseWorldPos, out int x, out int y);
        pathNodeWorldPos = pathfinding.GetGrid().GetWorldPosition(x, y);
        PathNode pathNode = pathfinding.GetNode(x, y);
        pathNode.isWalkable = false;

        return pathNode;
    }

    private Mesh CreateTileMesh(PathNode pathNode, float tileSize)
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];


        int x = pathNode.x;
        int y = pathNode.y;

        vertices[0] = new Vector3(tileSize * x, tileSize * y);
        vertices[1] = new Vector3(tileSize * x, tileSize * (y+1));
        vertices[2] = new Vector3(tileSize * (x+1), tileSize * (y+1));
        vertices[3] = new Vector3(tileSize *(x+1), tileSize * y);

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        // clockwise
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }
}
