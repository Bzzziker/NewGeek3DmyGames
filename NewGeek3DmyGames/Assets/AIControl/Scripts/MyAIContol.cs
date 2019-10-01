using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyGames
{
    public class MyAIContol : MonoBehaviour
    {
        NavMeshAgent _Agent;
        Animator _Ani;
        [SerializeField] GameObject _Target;
        bool _TargetVisible = false;
        [SerializeField] float _TimeTargetVisible = 10f;
        bool _TargetChase = false;
        [SerializeField] float _TimeChaseNotVisible = 10f;
        [SerializeField] float _Distance;
        [SerializeField] float _DistanceTargetAttack = 3f;
        [SerializeField] float _DistanceTargetBreak = 15f;
        public GameObject[] PatrolPoint;
        Vector3 _RandomPatrolPoint;
        bool _RandomPatrolPointSpawn = false;
        Random rnd;
        int _PatrolPointI;
        float _DistancePoint;
        public RaycastHit[] hits;
       

        public enum anicontrols
        {
            Run,
            Idle,
            Attack
        }

        private void Awake()
        {
            _Agent = gameObject.GetComponent<NavMeshAgent>();
            _Ani = gameObject.GetComponent<Animator>();
            _PatrolPointI = 0;
            if (PatrolPoint.Length == 0)
            {
                _RandomPatrolPointSpawn = true;
                _RandomPatrolPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

        void Start()
        {
         
        }

        void Update()
        {
            if (_Target != null)
            {
                _Distance =  Vector3.Distance(transform.position, _Target.transform.position);
                if ((_Distance < _DistanceTargetBreak) && _TargetChase )
                {
                    Attack(_Target, _Distance);
                }
                else
                {
                    _TargetChase = false;
                }
                //if(_TargetVisible)
            }

            if(_Target == null || !_TargetChase)
            {
                if(!_RandomPatrolPointSpawn)
                {
                    _MovePoint();
                }
                else
                {
                    _RandomMovePoint();
                }
                
            }

            _RayCast();
            #region Код для теста, в последствии будет удален

            if (Input.GetKeyDown(KeyCode.E))
            {

                gameObject.tag = "Player";
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                anicontorl(anicontrols.Attack);

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {

                anicontorl(anicontrols.Idle);
            }

            #endregion
        }

        #region Пока не используется
        public void anicontorl(anicontrols str)
        {
            switch (str)
            {
                case anicontrols.Idle:
                    {
                        _Ani.SetBool("Idle", true);
                        _Ani.SetBool("Run", false);
                        _Ani.SetBool("Attack", false);
                    }
                    break;
                case anicontrols.Run:
                    {
                        _Ani.SetBool("Idle", false);
                        _Ani.SetBool("Run", true);
                        _Ani.SetBool("Attack", false);
                    }
                    break;
                case anicontrols.Attack:
                    {
                        _Ani.SetBool("Idle", false);
                        _Ani.SetBool("Run", false);
                        _Ani.SetBool("Attack", true);
                    }
                    break;

            }
        }
        #endregion
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        _Target = other.gameObject;
        //    }

        //}
        public void Target(GameObject _target)
        {
            _Target = _target;
        }

        public void Attack(GameObject _target, float _distance)
        {
            if(_DistanceTargetAttack >= _distance)
            {
                Debug.Log("Attack");
            }
            else
            {
                _Agent.SetDestination(_target.transform.position);
            }
        }
        
        void _MovePoint()
        {   if(_PatrolPointI >= PatrolPoint.Length - 1 )
            {
                _PatrolPointI = 0;
            }

            if(Vector3.Distance(transform.position, PatrolPoint[_PatrolPointI].transform.position) < 2)
            {
                ++_PatrolPointI;
            }
            {
                _Agent.SetDestination(PatrolPoint[_PatrolPointI].transform.position);
            }
        }

        void _RandomMovePoint()
        {
            if (Vector3.Distance(transform.position, _RandomPatrolPoint) < 2)
            {
                _RandomPatrolPoint = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y, transform.position.z + Random.Range(-10f, 10f));
                _Agent.SetDestination(_RandomPatrolPoint);
            }

        }

        void _RayCast()
        {
            if (_Target == null) return;
            RaycastHit hit;
            Ray ray = new Ray(transform.position, _Target.transform.position - transform.position);
            
            if(Physics.Raycast(ray, out hit))
            {
                if (!_TargetChase)
                {
                    if (hit.collider.gameObject != _Target)
                    {
                        _TargetVisible = false;
                        Debug.Log("Не вижу" +hit.collider.name); // Удалится после тестирования
                    }
                    else
                    {
                        _TargetVisible = true;
                        _TargetChase = true;
                        Debug.Log("Вижуу"); // Удалится после тестирования
                    }
                }

                if(_TargetVisible)
                {
                    if (hit.collider.gameObject != _Target)
                    {
                        _TimeTargetVisible -= Time.deltaTime;
                        if (_TimeTargetVisible <= 0)
                        {
                            _TargetChase = false;
                            _TargetVisible = false;
                        }
                    }
                    else
                    {
                        _TimeTargetVisible = 10f;
                    }
                }

                Debug.DrawLine(ray.origin, _Target.transform.position, Color.red);
            }
            
            
            //hits = Physics.RaycastAll(transform.position, _Target.transform.position, 100f);


            //for(int i = 0; i < hits.Length; i++)
            //{
                
            //    //Debug.Log(hit);
            //    Debug.DrawRay(transform.position, _Target.transform.position, Color.green);
            //}


            //if(Physics.Raycast(transform.position,_Target.transform.position, out hit))
            //{
            //    
            //}

        }
    }
}
