using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    private float _distance;
    private float _angle;
    private string _sideUD;
    private string _sideLR;

    private Vector3 GetForwardVectorFrom(GameObject obj) => obj.GetComponentInChildren<Transform>().forward;


    private void Start()
    {
        if (player is null)
            throw new System.Exception("Error. Player isn't included.");
    }

    void Update()
    {
        this.CalculateValues();
        this.ShowInformation();
    }

    private float CalculateDistance() => Mathf.Sqrt(
            Mathf.Pow(player.transform.position.x - transform.position.x, 2) +
            Mathf.Pow(player.transform.position.y - transform.position.y, 2) +
            Mathf.Pow(player.transform.position.z - transform.position.z, 2));

    private float CalculateAngle() => Vector3.Angle(this.GetForwardVectorFrom(player), this.transform.forward);
    private Vector3 CalculateVectorBettweenObjectAnd(GameObject obj) =>  obj.transform.position - this.transform.position;

    private string CalculateSideVertical(Vector3 objToPlayer)
    {
        float dot = Vector3.Dot(this.GetForwardVectorFrom(this.gameObject).normalized, objToPlayer.normalized);
        if (dot > 0f)
            return "front";
        else if (dot < 0f)
            return "behind";
        return "center";
    }

    private string CalculateSideHorizontal(Vector3 objToPlayer)
    {
        float dot = Vector3.Dot(this.transform.right.normalized, objToPlayer.normalized);
        if (dot > 0f)
            return "right";
        else if (dot < 0f)
            return "left";
        return "center";
    }

    private void CalculateValues()
    {
        _distance = this.CalculateDistance();
        _angle = this.CalculateAngle();
        Vector3 objToPlayer = CalculateVectorBettweenObjectAnd(player);
        _sideUD = this.CalculateSideVertical(objToPlayer);
        _sideLR = this.CalculateSideHorizontal(objToPlayer);
    }

    private void ShowInformation()
    {
        //Debug.Log($"Distance : {_distance}");
        //Debug.Log($"Angle : {_angle}");
        Debug.Log($"Side : {_sideUD}, {_sideLR}");
    }
}
