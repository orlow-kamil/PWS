using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject ball = null;
    [SerializeField] private float power = 100;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos).normalized;

        GameObject newBall = Instantiate(ball, this.transform.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody>().AddForce(-worldPos * power);
    }
}
