using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{

    NavMeshAgent agent;


    public GameObject target;
    public bool attaked = false;
    public float distance;
    public float distance_max=10f;
    public float distance_min=2f;


    private void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
       
    }

    void Update()
    {
        if(attaked)
        {
            if((Vector3.Distance(this.gameObject.transform.position,target.transform.position)>distance_min))
            agent.SetDestination(target.transform.position);
        }

    }

    public void Moving(Vector3 moving_point)
    {
        agent.SetDestination(moving_point);
    }

    public void Attack(GameObject _target)
    {
        target = _target;
        agent.SetDestination(target.transform.position);
        attaked = true;
    }
    public void ToFollow(GameObject _target)
    {
        
    }
    public void Steal(GameObject _target)
    {

    }
    public void Abduct(GameObject _target)
    {

    }



}
