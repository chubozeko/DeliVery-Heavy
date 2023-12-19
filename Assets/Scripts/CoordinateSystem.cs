using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoordinateSystem : MonoBehaviour
{
    /*
    Unity Coordinate System:
        x = Vector3.right
        y = Vector3.up
        z = Vector3.forward
    */

    [Header("Axis Points")]
    public Transform origin;
    public Transform xAxis;
    public Transform yAxis;
    public Transform zAxis;

    [Header("Vectors")]
    public List<Vector3> positiveVectorList;
    public List<Vector3> negativeVectorList;

    void Start()
    {
        xAxis.position += Vector3.forward;
        yAxis.position += Vector3.left;
        zAxis.position += Vector3.up;

        UpdateVectorLists();

        // Debug.Log("[before rotation] X-axis position: " + (xAxis.position - transform.position));
        // Debug.Log("[before rotation] Y-axis position: " + (yAxis.position - transform.position));
        // Debug.Log("[before rotation] Z-axis position: " + (zAxis.position - transform.position));

        // RotateCoordinateSystem(0f, 90f, 0f);

        // xAxis.position = origin.position;
        // yAxis.position = origin.position;
        // zAxis.position = origin.position;

        // xAxis.position += Vector3.forward;
        // yAxis.position += Vector3.left;
        // zAxis.position += Vector3.up;

        // Debug.Log("X-axis position: " + (xAxis.position - transform.position));
        // Debug.Log("Y-axis position: " + (yAxis.position - transform.position));
        // Debug.Log("Z-axis position: " + (zAxis.position - transform.position));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Reset rotation
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            RotateCoordinateSystem(-90f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            RotateCoordinateSystem(90f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            RotateCoordinateSystem(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            RotateCoordinateSystem(0f, 90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            RotateCoordinateSystem(0f, 0f, -90f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            RotateCoordinateSystem(0f, 0f, 90f);
        }
    }

    public void RotateCoordinateSystem(float xRotation, float yRotation, float zRotation)
    {
        transform.Rotate(-yRotation, zRotation, xRotation);
        UpdateVectorLists();
    }

    void UpdateVectorLists()
    {
        // Clear vector lists
        positiveVectorList.Clear();
        negativeVectorList.Clear();
        // Get new vectors
        Vector3 xAxisV3 = xAxis.position - transform.position;
        Vector3 yAxisV3 = yAxis.position - transform.position;
        Vector3 zAxisV3 = zAxis.position - transform.position;
        // Positive vectors
        positiveVectorList.Add(xAxisV3);
        positiveVectorList.Add(yAxisV3);
        positiveVectorList.Add(zAxisV3);
        // Negative vectors
        negativeVectorList.Add(xAxisV3 * -1);
        negativeVectorList.Add(yAxisV3 * -1);
        negativeVectorList.Add(zAxisV3 * -1);
    }

    public int GetWeightValue(Vector3 vect)
    {
        foreach (Vector3 v in positiveVectorList)
        {
            if (vect.Equals(v))
                return 1;
        }

        foreach (Vector3 v in negativeVectorList)
        {
            if (vect.Equals(v))
                return -1;
        }

        return 0;
    }
}
