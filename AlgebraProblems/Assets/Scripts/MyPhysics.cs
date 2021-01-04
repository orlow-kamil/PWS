using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyPhysics : MonoBehaviour
{
    [SerializeField] private bool isReflect = true;
    [SerializeField] private float eta = 1.5f;
    private Rigidbody _rgb;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody>();
    }
    
    private Vector3 Reflect(Vector3 input, Vector3 normal) => input - (2f * Vector3.Dot(input, normal) * normal);

    private Vector3 Refract(Vector3 input, Vector3 normal, float eta)
    {
        float dotNormalInput = Vector3.Dot(normal, input);
        float k = 1f - (eta * eta * (1f - (dotNormalInput * dotNormalInput)));

        if (k < 0f)
            return Vector3.zero;
        else
            return eta * input - (eta * dotNormalInput + Mathf.Sqrt(k)) * normal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isReflect)
            _rgb.velocity = this.Reflect(_rgb.velocity, collision.contacts[0].normal);
        else
            _rgb.velocity = this.Refract(_rgb.velocity, collision.contacts[0].normal, eta);
    }
}
