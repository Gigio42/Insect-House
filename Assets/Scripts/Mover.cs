using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 6f;

        AIController aIController;

        NavMeshAgent navMeshAgent;

        private void Awake() 
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            aIController = GetComponent<AIController>();
        }

        private void Update() 
        {
            if (aIController.HaveAggro())
            {
                MoveTo(aIController.targetToChase.transform.position, 1f);
            }

            UpdateAnimator();
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponentInChildren<Animator>().SetFloat("FowardSpeed", speed);
        }
    }
}
