using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject ball = null;
    [SerializeField][Range(5,50)] private float power = 20;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject newBall = Instantiate(ball, this.transform.position, Quaternion.identity);
        float initialSpeed = newBall.GetComponent<MyPhysics>().InitialSpeed;
        newBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * initialSpeed * power);
    }
}
