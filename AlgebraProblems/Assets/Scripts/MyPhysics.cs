using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyPhysics : MonoBehaviour
{
    public float InitialSpeed { get => initialSpeed; }

    [SerializeField] private float initialSpeed = 20;
    [SerializeField] private float eta = 1.5f;
    [SerializeField] private bool isReflect = true;
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
            return (eta * input) - (eta * dotNormalInput + Mathf.Sqrt(k)) * normal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length == 0)
            return;

        var firstCollision = collision.contacts[0];
        if (isReflect)
            _rgb.velocity = this.Reflect(transform.forward, firstCollision.normal) * initialSpeed;
        else
            _rgb.velocity = this.Refract(transform.forward, firstCollision.normal, eta) * initialSpeed;

        Debug.DrawRay(firstCollision.point, _rgb.velocity * 10, Color.red, 5);
    }
}
