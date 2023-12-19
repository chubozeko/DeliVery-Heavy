using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{
    public CoordinateSystem cs;
    public Vector3 lastMoveVector;

    public TMP_Text text_DroneWeight;
    public int weightMultiplier = 1;
    private int droneWeight = 0;
    void Start()
    {
        cs = FindObjectOfType<CoordinateSystem>();
        text_DroneWeight.text = droneWeight.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.position += new Vector3(0, 0, -1);
            lastMoveVector = new Vector3(0, 0, -1);
            UpdateWeight();
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            transform.position += new Vector3(0, 0, 1);
            lastMoveVector = new Vector3(0, 0, 1);
            UpdateWeight();
        }
        else if (Input.GetKeyDown(KeyCode.W)) 
        {
            transform.position += new Vector3(-1, 0, 0);
            lastMoveVector = new Vector3(-1, 0, 0);
            UpdateWeight();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(1, 0, 0);
            lastMoveVector = new Vector3(1, 0, 0);
            UpdateWeight();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position += new Vector3(0, 1, 0);
            lastMoveVector = new Vector3(0, 1, 0);
            UpdateWeight();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position += new Vector3(0, -1, 0);
            lastMoveVector = new Vector3(0, -1, 0);
            UpdateWeight();
        }

        
    }

    void UpdateWeight()
    {
        int weightValue = cs.GetWeightValue(lastMoveVector);
        droneWeight += weightValue * weightMultiplier;
        text_DroneWeight.text = droneWeight.ToString();
    }
}
