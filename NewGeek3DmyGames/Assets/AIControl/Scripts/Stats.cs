using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    GameObject _CameraMotor;
    [SerializeField] GameObject _PositionHouse; 
    double _HealPoint; 
    
    GameObject _Work = null; 
    int _ProfessionLevel=0; 
    float _NewJobSearchTime = 100f;
   
    void Start()
    {
        _CameraMotor = GameObject.FindGameObjectWithTag("CameraMotor");
    }

    void Update()
    {
        if(_Work == null)
        {
            if (_NewJobSearchTime <= 0)
            {
                Jobs();
            }
            else
            {
                _NewJobSearchTime -= Time.deltaTime;
            }
        }
    }

    public void Jobs()
    {
        _Work = _CameraMotor.GetComponent<WorkForAi>().WorkSearches(_ProfessionLevel,_PositionHouse);
        if (_Work == null)
            _NewJobSearchTime = 500f;
    }
}
