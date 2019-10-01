using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;


public class MouseControl : MonoBehaviour
{
  
    public List<GameObject> ActivObject;

    public GameObject MenuRightButtonMouseEnemy;
    public GameObject MenuRightButtonMouseInfrastructure;
    public GameObject MenuRightButtonMouseTarget;

    RectTransform _Canvas;

    public Texture2D CursorTextureBase;
    public Texture2D CursorTexture;
    public CursorMode CursorMode = CursorMode.Auto;

    [SerializeField]
    float _Speed = 100;

    [SerializeField]
    GameObject test; // переменная несет чисто тестовыйх характер, после чего будет удалена
    [SerializeField]
    string test3;  // переменная несет чисто тестовыйх характер, после чего будет удалена

    public RaycastHit hit;

    public GameObject BuildingGo;
    public GameObject CompletionBuilding;
    public bool BuildingBo=false;
    public LayerMask Mask;
    int _TrigerEnter;

    float _MouceScrol;
    float _MouceScrolMin=10f;
    float _MouceScrolMax=25f;
    float _MouceScrolSpeed = 100f;
    int _MinMaxScreenIntend = 2;

    void Start()
    {
        ActivObject = new List<GameObject>();
        MenuRightButtonMouseEnemy = GameObject.FindGameObjectWithTag("MenuRightButtonMouseEnemy");
        MenuRightButtonMouseEnemy.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Deselect();
        }
        
        MouseMove();
        #region // MouseMove в тестовом режиме 
        //var TimeDeltaTime = Time.deltaTime;
        //if (Input.mousePosition.x > 2) transform.position += transform.right * TimeDeltaTime * speed; //пр
        //if (Input.mousePosition.x < Screen.width - 2) this.transform.position -= transform.right * TimeDeltaTime * speed; //лев
        //if (Input.mousePosition.y > 2) this.transform.position += transform.forward * TimeDeltaTime * speed; //пр
        //if (Input.mousePosition.y < Screen.height - 2) this.transform.position -= transform.forward * TimeDeltaTime * speed; //пр

        //MouceScrol = Input.GetAxis("Mouse ScrollWheel");
        //if ((MouceScrol > 0.1) && (transform.position.y >= MouceScrolMin))
        //{
        //    transform.position -= transform.up * Time.deltaTime * MouceScrolSpeed;
        //}
        //if ((MouceScrol < -0.1) && (transform.position.y <= MouceScrolMax) )
        //{
        //    transform.position += transform.up * Time.deltaTime * MouceScrolSpeed;
        //}
        #endregion
              
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if ((Physics.Raycast(ray, out hit)) && BuildingBo == false)
        {
            test = hit.collider.gameObject;
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
            if (ActivObject.Count > 0 && hit.collider.CompareTag("Enemy"))
            {
                Cursor.SetCursor(CursorTexture, Vector2.zero, CursorMode);
            }
            else
            {
                Cursor.SetCursor(CursorTextureBase, Vector2.zero, CursorMode);
            }

            if (Input.GetMouseButtonDown(0))
            {
                var test2 = hit.collider.name;
                test3 = test2;

                MenuRightButtonMouseEnemy.SetActive(false);

                if (hit.collider.CompareTag("Player"))
                {
                    if((Input.GetKey(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightShift)))
                    {
                        if (!ActivObject.Any(ob => ob == hit.collider.gameObject))
                        {
                            ActivObject.Add(hit.collider.gameObject);
                        }
                      
                    }
                    else
                    {
                        ActivObject.Clear();
                        ActivObject.Add(hit.collider.gameObject);
                    }
                   
                }
                #region На удаление после проверки работоспособости
                //if ((hit.collider.tag == "Player")&&(Input.GetKey(KeyCode.LeftShift))||(Input.GetKeyDown(KeyCode.RightShift)))
                //{

                //    Activ_Object.Add(hit.collider.gameObject);
                //}
                #endregion

                if (hit.collider.CompareTag("PlayerObject"))
                {
                    ActivObject.Clear();
                    ActivObject.Add(hit.collider.gameObject);
                }
                #region На удаление после проверки работоспособости
                //if (Activ_Object.Count == 0)
                //{
                //    Activ_Object.Add(hit.collider.gameObject);
                //}
                #endregion

                if (ActivObject != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        #region На удаление после проверки работоспособости
                        //for(int i=0; i<Activ_Object.Count;i++)
                        //{
                        //Activ_Object[i].GetComponent<PlayerControl>().Moving(hit.point);
                        //}
                        //if(hit.collider.tag==)
                        #endregion
                        if ((hit.collider.CompareTag("Enemy")) || (hit.collider.CompareTag("EnemyObject")))
                        {
                            foreach (GameObject go in ActivObject)
                            {
                                go.GetComponent<PlayerControl>().Attack(hit.collider.gameObject);

                            }                          
                        }
                        else
                        {
                            foreach (GameObject go in ActivObject)
                            {
                                go.GetComponent<PlayerControl>().attaked = false;
                                go.GetComponent<PlayerControl>().Moving(hit.point);
                                
                            }
                        }

                    }
                }
            }
 
            if(Input.GetMouseButtonDown(1))
            {
                if(hit.collider.CompareTag("Enemy"))
                {
                    MenuRightButtonMouseEnemy.SetActive(true);
                    //44 23 это магические числа, которые потом будут переделаны в переменные
                    MenuRightButtonMouseTarget = hit.collider.gameObject;
                    MenuRightButtonMouseEnemy.transform.position = new Vector2 (Input.mousePosition.x + 44, Input.mousePosition.y + 23.5f);
                 }
                if(hit.collider.CompareTag("Infrastructure"))
                {
                    MenuRightButtonMouseTarget = hit.collider.gameObject;
                }
            }

            if(BuildingGo!=null)
            {
                //go_building.transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z);
               
            }
        }

        if((Physics.Raycast(ray, out hit, 200f, Mask)) && BuildingBo == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _TrigerEnter = CompletionBuilding.GetComponent<InfrastructureContorl>().TrigerEnter;
                if (_TrigerEnter <= 0)
                {
                    CompletionBuilding.GetComponent<InfrastructureContorl>().MoveStop(hit.point);
                    CompletionBuilding = null;
                    BuildingBo = false;
                }
            }

            if (CompletionBuilding != null)
            {
                CompletionBuilding.transform.position = hit.point;

            }
        }
    }

    void MouseMove()
    {
        var TimeDeltaTime = Time.deltaTime;
        if (Input.mousePosition.x > _MinMaxScreenIntend) transform.position += transform.right * TimeDeltaTime * _Speed; 
        if (Input.mousePosition.x < Screen.width - _MinMaxScreenIntend) transform.position -= transform.right * TimeDeltaTime * _Speed; 
        if (Input.mousePosition.y > _MinMaxScreenIntend) transform.position += transform.forward * TimeDeltaTime * _Speed; 
        if (Input.mousePosition.y < Screen.height - _MinMaxScreenIntend) transform.position -= transform.forward * TimeDeltaTime * _Speed; 

        _MouceScrol = Input.GetAxis("Mouse ScrollWheel");
        if ((_MouceScrol > 0.1) && (transform.position.y >= _MouceScrolMin))
        {
            transform.position -= transform.up * TimeDeltaTime * _MouceScrolSpeed;
        }
        if ((_MouceScrol < -0.1) && (transform.position.y <= _MouceScrolMax))
        {
            transform.position += transform.up * TimeDeltaTime * _MouceScrolSpeed;
        }
    }


    public void Building(GameObject go)
    {
        //go_building = null;
        //completion_building = null;
        //ActivObject.Clear();
        //go_building = go;
        Deselect();
        BuildingBo = true;
        Instantiate(go, hit.point, Quaternion.identity);
    }

    public void Building_test(GameObject go)
    {
        CompletionBuilding = go;
    }


    void Deselect()
    {
        BuildingGo = null;
        BuildingBo = false;
        MenuRightButtonMouseEnemy.SetActive(false);
        ActivObject.Clear();
        if (CompletionBuilding != null)
            CompletionBuilding.GetComponent<InfrastructureContorl>()._destroy();
    }


    public void R_menu(string r)
    {
        MenuRightButtonMouseEnemy.SetActive(false);
        switch (r)
        {
            case "Attack":
                foreach (GameObject go in ActivObject)
                {
                    Debug.Log("attack");
                    go.GetComponent<PlayerControl>().Attack(MenuRightButtonMouseTarget);
                }
                break;
            case "ToFollow":
                foreach (GameObject go in ActivObject)
                {
                    go.GetComponent<PlayerControl>().ToFollow(MenuRightButtonMouseTarget);
                }
                break;
            case "Steal":
                foreach (GameObject go in ActivObject)
                {
                    go.GetComponent<PlayerControl>().Steal(MenuRightButtonMouseTarget);
                }
                break;
            case "Abduct":
                foreach (GameObject go in ActivObject)
                {
                    go.GetComponent<PlayerControl>().Abduct(MenuRightButtonMouseTarget);
                }
                break;
        }
    }
    public void Position()
    {
        Debug.Log("zazaza");
    }

}
