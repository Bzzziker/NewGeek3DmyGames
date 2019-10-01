using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Parrent : MonoBehaviour
    {
        [SerializeField] GameObject _Parent;
        GameObject _Target;
        private void Awake()
        {
            _Parent = gameObject.transform.parent.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _Parent.GetComponent<MyAIContol>().Target(other.gameObject);
            }
        }
    }
}

