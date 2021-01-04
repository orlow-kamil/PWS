using UnityEngine;

namespace Point
{
    public class PointPosition : MonoBehaviour, IPosition
    {
        public Vector3 Position { get => this.transform.position; }
    }
}