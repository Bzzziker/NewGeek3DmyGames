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
    


    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        Activ_Object = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x > 2) this.transform.position += transform.right * Time.deltaTime * speed; //пр
        if (Input.mousePosition.x < Screen.width - 2) this.transform.position -= transform.right * Time.deltaTime * speed; //лев
        if (Input.mousePosition.y > 2) this.transform.position += transform.forward * Time.deltaTime * speed; //пр
        if (Input.mousePosition.y < Screen.height - 2) this.transform.position -= transform.forward * Time.deltaTime * speed; //пр

        //RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
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
                        foreach (GameObject go in Activ_Object)
                        {
                            go.GetComponent<PlayerControl>().Moving(hit.point);
                        }
                    }
                }
            }
            
            


        }


    }
}
