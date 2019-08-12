using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{


    [SerializeField]
    float speed;

    [SerializeField]
    GameObject test;


     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x > 2) this.transform.position += transform.right * Time.deltaTime * speed; //пр
        if (Input.mousePosition.x < Screen.width - 2) this.transform.position -= transform.right * Time.deltaTime * speed; //лев
        if (Input.mousePosition.y > 2) this.transform.position += transform.forward * Time.deltaTime * speed; //пр
        if (Input.mousePosition.y < Screen.height - 2) this.transform.position -= transform.forward * Time.deltaTime * speed; //пр

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            test = hit.collider.gameObject;


        }
    }
}
