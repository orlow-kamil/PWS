using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Projection : MonoBehaviour
{
    [SerializeField] private Transform p1Transform = null;
    [SerializeField] private Transform p2Transform = null;
    [SerializeField] private Transform playerTransform = null;

    private LineRenderer _lineRenderer;
    private Vector3 _path;
    private Vector3 _p1ToPoint;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, p1Transform.position);
        _lineRenderer.SetPosition(1, p2Transform.position);
    }

    private void SetupProjection(LineRenderer line, Transform point)
    {
        Vector3 pathP1 = line.GetPosition(0);
        Vector3 pathP2 = line.GetPosition(1);
        _path = pathP2 - pathP1;
        _p1ToPoint = point.position - pathP1;
    }

    private float VectorProjection(LineRenderer line, Transform point)
    {
        SetupProjection(line, point);

        Vector3 projection = Vector3.Dot(_p1ToPoint, _path) / Vector3.Dot(_path, _path) * _path;
        float progress = Mathf.Sqrt( projection.sqrMagnitude / _path.sqrMagnitude);

        return Mathf.Clamp(progress , 0, 1);
    }

    private float ScalarProjection(LineRenderer line, Transform point)
    {
        SetupProjection(line, point);

        float projection = Vector3.Dot(_p1ToPoint, _path) / _path.magnitude;
        float progress = projection / _path.magnitude;

        return Mathf.Clamp(progress , 0, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Vector projection : {VectorProjection(_lineRenderer, playerTransform)}");
            Debug.Log($"Scalar projection : {ScalarProjection(_lineRenderer, playerTransform)}");
        }
    }
}
