using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrastructureContorl : MonoBehaviour
{
    public GameObject CameraMotor;
    public int TrigerEnter = 0;

    [SerializeField]
    float _HeightBuilding;

    void Start()
    {
        CameraMotor = GameObject.FindGameObjectWithTag("CameraMotor");
        CameraMotor.GetComponent<MouseControl>().Building_test(gameObject);
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Job_Search(3, 5);
        }
      }

    public void Job_Search(int level, float salory)
    {
        CameraMotor.GetComponent<WorkForAi>().NewJob(gameObject, salory);
    }

    public void _destroy()
    {
        Destroy(gameObject);
    }

    public void Move(Vector3 v3)
    {
        this.gameObject.transform.position = v3;
    }

    public void MoveStop(Vector3 v3)
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        this.gameObject.transform.position = new Vector3(v3.x, v3.y + (_HeightBuilding), v3.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Untagged"))
            TrigerEnter++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Untagged"))
            TrigerEnter--;
    } 
}
