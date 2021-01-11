using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] Transform background;
    private Grid grid;
    private void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(20, 0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilitsClass.GetMouseWorldPosition(background.position.z), 56);
            //Debug.Log(UtilitsClass.GetMouseWorldPosition(background.position.z).ToString());
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Value: " + grid.GetValue(UtilitsClass.GetMouseWorldPosition(background.position.z)).ToString());
        }
    }
}
