using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotateSpeed = 10f;

    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, v) * speed * Time.deltaTime;

        this.transform.Translate(movement);
    }

    private void Rotate()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, h, 0) * rotateSpeed * Time.deltaTime;

        this.transform.Rotate(movement);
    }

    private void Update()
    {
        Move();
        Rotate();
    }
}
