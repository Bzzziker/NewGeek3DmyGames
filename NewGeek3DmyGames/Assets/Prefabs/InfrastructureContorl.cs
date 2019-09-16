using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrastructureContorl : MonoBehaviour
{
    public GameObject CameraMotor;


    //Для проверки тригера
    public int triger_enter=0;

    [SerializeField]
    float height_building;
    // Start is called before the first frame update
    void Start()
    {
        CameraMotor = GameObject.FindGameObjectWithTag("CameraMotor");
        CameraMotor.GetComponent<MouseControl>().Building_test(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Job_Search(3, 5);
        }
        //transform.position = CameraMotor.GetComponent<MouseControl>().hit.point;
        //transform.position = new Vector2(CameraMotor.GetComponent<MouseControl>().hit.point.x, CameraMotor.GetComponent<MouseControl>().hit.point.y);
    }

    public void Job_Search(int level, float salory)
    {
        CameraMotor.GetComponent<WorkForAi>().NewJob(this.gameObject, level, salory);
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
        this.gameObject.transform.position = new Vector3(v3.x,v3.y+(height_building),v3.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag!="Untagged")
        triger_enter++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Untagged")
            triger_enter--;
    }



   
}
