using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyAIContol : MonoBehaviour
{
    NavMeshAgent agent;
    Animator ani;



    public enum anicontrols
    {
        Run,
        Idle,
        Attack
    }




    private void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        ani = this.gameObject.GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void Update()
    {
        ///Код для теста!!!!
        if(Input.GetKeyDown(KeyCode.E))
        {

            this.gameObject.tag = "Player";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anicontorl(anicontrols.Attack);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            anicontorl(anicontrols.Idle);
        }


        ///Конец тест кода
    }


    public void anicontorl(anicontrols str)
    {
        switch (str)
        {
            case anicontrols.Idle:
                {
                    this.ani.SetBool("Idle", true);
                    this.ani.SetBool("Run", false);
                    this.ani.SetBool("Attack", false);
                }
                break;
            case anicontrols.Run:
                {
                    this.ani.SetBool("Idle", false);
                    this.ani.SetBool("Run", true);
                    this.ani.SetBool("Attack", false);
                }
                break;
            case anicontrols.Attack:
                {
                    this.ani.SetBool("Idle", false);
                    this.ani.SetBool("Run", false);
                    this.ani.SetBool("Attack", true);
                }
                break;

        }
    }

}
