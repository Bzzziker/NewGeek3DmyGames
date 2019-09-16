using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject cameraMotor;
    public GameObject[] bildings; 
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bildings(string name)
    {
        //switch(name)
        //
        //    case "Sawmill":
        //        cameraMotor.GetComponent<MouseControl>().Building(bildings[0]);
        //        break;

        //}

        foreach(GameObject go in bildings)
        {
            if(go.name==name)
            {
                cameraMotor.GetComponent<MouseControl>().Building(go);
            }
        }
    }


}

