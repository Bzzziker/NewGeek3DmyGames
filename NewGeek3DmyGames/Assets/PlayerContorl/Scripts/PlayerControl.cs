using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{

    NavMeshAgent agent;


    private void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
       
    }
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Moving(Vector3 moving_point)
    {
        agent.SetDestination(moving_point);
    }
}
