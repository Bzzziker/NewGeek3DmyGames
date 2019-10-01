using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent _agent;
    public GameObject target;
    public bool attaked = false;
    public float distance;
    [SerializeField] float _MaxDistance = 10f;
    [SerializeField] float _MinDistance = 2f;


    private void Awake()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
       
    }

    void Update()
    {
        if(attaked)
        {
            if((Vector3.Distance(gameObject.transform.position, target.transform.position) > _MinDistance))
                _agent.SetDestination(target.transform.position);
        }
    }

    public void Moving(Vector3 moving_point)
    {
        _agent.SetDestination(moving_point);
    }

    public void Attack(GameObject _target)
    {
        target = _target;
        _agent.SetDestination(target.transform.position);
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
