using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    GameObject _CameraMotor;
    public GameObject[] Bilding;

    void Awake()
    {
        _CameraMotor = GameObject.FindGameObjectWithTag("CameraMotor");
    }
    public void Bildings(string name)
    {
        foreach(GameObject go in Bilding)
        {
            if(go.name==name)
            {
                _CameraMotor.GetComponent<MouseControl>().Building(go);
            }
        }
    }
}

