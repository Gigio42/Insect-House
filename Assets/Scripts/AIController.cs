using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 3f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] public Transform targetToChase;

        public bool HaveAggro()
        {
            float distanceToPlayer = Vector3.Distance(targetToChase.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        public bool CanAttack()
        {
            float distanceToPlayer = Vector3.Distance(targetToChase.transform.position, transform.position);
            return distanceToPlayer < attackDistance;
        }

        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }
    }
}
