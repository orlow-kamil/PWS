using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingMovementHandler : MonoBehaviour
{
    [SerializeField] private Vector2Int startPositon = Vector2Int.zero;
    [SerializeField] private float speed = 40f;

    private List<Vector3> pathVectorList = null;
    private int currentPathIndex = 0;

    public Vector3 GetPosition() => this.transform.position;
    public void SetStartPosition() => this.transform.position = Pathfinding.Instance.GetGrid().GetWorldPosition(startPositon.x, startPositon.y) + Pathfinding.Instance.GetGrid().GetCellSize() * Vector3.one * 0.5f;

    public void SetTargetPosition(Vector3 targetPos)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPos);

        if (pathVectorList != null && pathVectorList.Count > 1)
            pathVectorList.RemoveAt(0);

        StartCoroutine(StartMoveOnPath());
    }

    private void MovementHandler()
    {
        if (pathVectorList == null)
            return;

        Vector3 targetPos = pathVectorList[currentPathIndex];
        if (Vector3.Distance(this.transform.position, targetPos) > 1f)
        {
            Vector3 movement = (targetPos - this.transform.position).normalized;
            this.transform.position += movement * speed * Time.deltaTime;
        }
        else
        {
            currentPathIndex++;
            if (currentPathIndex >= pathVectorList.Count)
                StopMoving();
        }

    }

    private void StopMoving() => pathVectorList = null;

    private IEnumerator StartMoveOnPath()
    {
        while(pathVectorList != null)
        {
            MovementHandler();
            yield return null;
        }
    }
}
