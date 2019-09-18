using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using UnityEngine.EventSystems;


public class MouseControl : MonoBehaviour
{
    //Выделеные объекты
    public List<GameObject> Activ_Object;

    //Курсор
    public Texture2D cursor_texture_base;
    public Texture2D cursor_texture;
    public CursorMode cursor_mode = CursorMode.Auto;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject test;
    [SerializeField]
    string test3;
    


    public RaycastHit hit;

    //Строительство
    public GameObject go_building;
    public GameObject completion_building;
    public bool bo_building=false;
    public LayerMask mask;
    public int triger_enter;




    float MouceScrol;
    float MouceScrol_min=10f;
    float MouceScrol_max=25f;
    float MouceScrol_speed = 100f;

    

    // Start is called before the first frame update
    void Start()
    {
        Activ_Object = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            go_building = null;
            bo_building = false;
            Activ_Object.Clear();
            if (completion_building != null)
                completion_building.GetComponent<InfrastructureContorl>()._destroy();

        }


        //Перемещение мыши
        if (Input.mousePosition.x > 2) this.transform.position += transform.right * Time.deltaTime * speed; //пр
        if (Input.mousePosition.x < Screen.width - 2) this.transform.position -= transform.right * Time.deltaTime * speed; //лев
        if (Input.mousePosition.y > 2) this.transform.position += transform.forward * Time.deltaTime * speed; //пр
        if (Input.mousePosition.y < Screen.height - 2) this.transform.position -= transform.forward * Time.deltaTime * speed; //пр

        MouceScrol = Input.GetAxis("Mouse ScrollWheel");
        if ((MouceScrol > 0.1) && (transform.position.y >= MouceScrol_min))
        {
            transform.position -= transform.up * Time.deltaTime * MouceScrol_speed;
        }
        if ((MouceScrol < -0.1) && (transform.position.y <= MouceScrol_max) )
        {
            transform.position += transform.up * Time.deltaTime * MouceScrol_speed;
        }






        //RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if ((Physics.Raycast(ray, out hit))&&bo_building==false)
        {
            test = hit.collider.gameObject;
            if (EventSystem.current.IsPointerOverGameObject())
                return;


            if (Activ_Object.Count>0&&hit.collider.tag=="Enemy")
            {
                Cursor.SetCursor(cursor_texture, Vector2.zero, cursor_mode);
            }
            else
            {
                Cursor.SetCursor(cursor_texture_base, Vector2.zero, cursor_mode);
            }

            if (Input.GetMouseButtonDown(0))
            {
                
                var test2 = hit.collider.name;
                test3 = test2;

                if (hit.collider.tag=="Player")
                {
                    if((Input.GetKey(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightShift)))
                    {
                        if (!Activ_Object.Any(ob => ob ==hit.collider.gameObject))
                        {
                            // Activ_Object.Clear();
                            Activ_Object.Add(hit.collider.gameObject);

                        }
                      
                    }
                    else
                    {
                        Activ_Object.Clear();
                        Activ_Object.Add(hit.collider.gameObject);
                    }
                   

                }

                //if ((hit.collider.tag == "Player")&&(Input.GetKey(KeyCode.LeftShift))||(Input.GetKeyDown(KeyCode.RightShift)))
                //{
                    
                //    Activ_Object.Add(hit.collider.gameObject);
                //}


                if (hit.collider.tag == "PlayerObject")
                {
                    Activ_Object.Clear();
                    Activ_Object.Add(hit.collider.gameObject);
                }

                //if (Activ_Object.Count == 0)
                //{
                //    Activ_Object.Add(hit.collider.gameObject);
                //}




                if (Activ_Object != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //for(int i=0; i<Activ_Object.Count;i++)
                        //{
                        //Activ_Object[i].GetComponent<PlayerControl>().Moving(hit.point);
                        //}
                        //if(hit.collider.tag==)
                        foreach (GameObject go in Activ_Object)
                        {
                            go.GetComponent<PlayerControl>().Moving(hit.point);
                        }


                    }
                }
            }
            
            

            if(go_building!=null)
            {
                //go_building.transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z);
               
            }



        }

        if((Physics.Raycast(ray, out hit,1000f, mask))&&bo_building==true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                triger_enter = completion_building.GetComponent<InfrastructureContorl>().triger_enter;
                if (triger_enter <= 0)
                {
                    completion_building.GetComponent<InfrastructureContorl>().MoveStop(hit.point);
                    completion_building = null;
                    bo_building = false;
                }
            }


            if (completion_building != null)
                completion_building.transform.position = hit.point;

         


        }




    }
    public void Building(GameObject go)
    {
        go_building = null;
        completion_building = null;
        Activ_Object.Clear();
        go_building = go;
        bo_building = true;
        Instantiate(go_building, hit.point, Quaternion.identity);
    }

    public void Building_test(GameObject go)
    {
        completion_building = go;
    }
}
