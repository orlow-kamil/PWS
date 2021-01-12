using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{
    [SerializeField] Transform background;
    private Grid<BoolGridObject> grid;
    private void Start()
    {
        grid = new Grid<BoolGridObject>(10, 5, 20f, default, (Grid<BoolGridObject> b, int x, int y) => new BoolGridObject(b, x, y));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilitsClass.GetMouseWorldPosition(background.position.z);
            //Debug.Log(position.ToString());
            grid?.GetGridObject(position).AddValue(true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Value: " + grid.GetGridObject(UtilitsClass.GetMouseWorldPosition(background.position.z)).ToString());
        }
    }
}

public class BoolGridObject
{
    private Grid<BoolGridObject> grid;
    private int x;
    private int y;
    private bool value; 

    public BoolGridObject(Grid<BoolGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(bool value)
    {
        this.value = value;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
