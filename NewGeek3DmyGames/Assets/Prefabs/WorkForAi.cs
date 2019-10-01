using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkForAi: MonoBehaviour
{
    List<DataBaseWorks> _DataBaseWorks;
       
    void Start()
    {
        _DataBaseWorks = new List<DataBaseWorks>();
    }

    public void NewJob(GameObject go,float salary)
    {
        _DataBaseWorks.Add(new DataBaseWorks() { ObjectWork = go, Salary = salary });
    }

    public GameObject WorkSearches(int Level,GameObject house)
    {
        GameObject _Resul=null;
        float dist;
        float _MaxSalory=0;
        if(_DataBaseWorks.Count > 0)
        {
            foreach (DataBaseWorks DBWorks in _DataBaseWorks)
            {
                //if (DataBaseWorks.Level <= Level)
                //{
                    if( _MaxSalory<= DBWorks.Salary)
                    {
                        _MaxSalory = DBWorks.Salary;
                        _Resul = DBWorks.ObjectWork;
                    }                    
                //}
            }
        } 
     return _Resul;
    }
}

public class DataBaseWorks
{
    public GameObject ObjectWork;
    public int Level;
    public float Salary;
}
