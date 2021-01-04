using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Point;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PatrollingSystem : MonoBehaviour
    {
        [SerializeField] private List<PointPosition> pointList;
        [SerializeField] [Range(0.1f, 0.5f)] float remainingDistance = 0.25f;

        private int _pointIndex = 0;
        private NavMeshAgent _agent;

        private Vector3 GetPointPosFromPath(int index) => pointList[index].Position;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            if (pointList.Count == 0)
                throw new System.Exception("Path is empty");
        }
        private void SetNewDestination() => _agent.destination = GetPointPosFromPath(_pointIndex);

        private void GoToNextPoint()
        {
            SetNewDestination();
            _pointIndex++;
            _pointIndex = _pointIndex <= pointList.Count - 1 ? _pointIndex : 0;
        }

        private void Start()
        {
            GoToNextPoint();
        }


        private void Update()
        {
            if (!_agent.pathPending && _agent.remainingDistance < remainingDistance)
                GoToNextPoint();
        }
    }
}