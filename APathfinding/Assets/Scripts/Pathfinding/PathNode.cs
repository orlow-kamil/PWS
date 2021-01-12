using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathNode : MonoBehaviour, IEquatable<PathNode>
{
    private Grid<PathNode> grid;
    public int x;
    public int y;

    public int gCost, hCost, fCost;
    public bool isWalkable;

    public PathNode previousNode;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

    public void CalculateFCost() => fCost = gCost + hCost;

    public override string ToString()
    {
        return $"{x}, {y}";
    }
    public bool Equals(PathNode other)
    {
        return this.x == other.x && this.y == other.y;
    }

    public static bool operator ==(PathNode obj1, PathNode obj2)
    {
        if (ReferenceEquals(obj1, obj2))
        {
            return true;
        }
        if (obj1 is null)
        {
            return false;
        }
        if (obj2 is null)
        {
            return false;
        }

        return obj1.Equals(obj2);
    }
    public static bool operator !=(PathNode obj1, PathNode obj2)
    {
        return !(obj1 == obj2);
    }

    public override bool Equals(object other)
    {
        return Equals(other as PathNode);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
