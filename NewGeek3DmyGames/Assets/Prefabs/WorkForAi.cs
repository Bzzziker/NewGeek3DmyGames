using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkForAi : MonoBehaviour
{
    //Массив объектов с рабочими местами
    List<GameObject> job_go;
    public List<BD_Work> bd_work;

    // Start is called before the first frame update
    void Start()
    {
        bd_work = new List<BD_Work>();
        job_go = new List<GameObject>();
    }


    // Update is called once per frame3
    void Update()
    {
        
    }


    public void NewJob(GameObject go,int level,float salary)
    {
        bd_work.Add(new BD_Work() { go_work = go, Level = level,Salary=salary });
        Debug.Log("exy");
        
        //job_go.Add(go);
    }

    public GameObject Work_Searches(int Level,GameObject house)
    {
        GameObject resul=null;
        float dist;
        float max_salory=0;
        if(bd_work.Count>0)
        {
            foreach (BD_Work bd in bd_work)
            {
                if (bd.Level <= Level)
                {
                    if( max_salory<=bd.Salary)
                    {
                        max_salory = bd.Salary;
                        resul = bd.go_work;
                    }
                    
                }
            }
        }
      




        return resul;
    }

}
public class BD_Work
{
    public GameObject go_work;
    public int Level;
    public float Salary;
 
}
