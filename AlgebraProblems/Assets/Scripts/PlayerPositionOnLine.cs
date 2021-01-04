using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionOnLine : MonoBehaviour
{
    [SerializeField] private Transform startPoint = null;
    [SerializeField] private Transform endPoint = null;

    [SerializeField][Range(0.1f, 1f)] private float tick = 0.25f;

    private Vector3 _currentPlayerPos;

    private void Update()
    {
        _currentPlayerPos = transform.position;
    }

    private IEnumerator GenerateFunction(float tick)
    {
        while (true) { }
        DrawFunction(_currentPlayerPos);
        yield return new WaitForSeconds(tick);
    }

    private float CalculatePlayerPositionRelativeFrom(Vector3 start, Vector3 end) => 0f;

    private void DrawFunction(Vector3 player)
    {
        Gizmos.DrawLine(startPoint.position, endPoint.position);
    }
}
