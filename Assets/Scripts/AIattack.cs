using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AIattack : MonoBehaviour
    {

        AIController aIController;

        private void Awake() 
        {
            aIController = GetComponent<AIController>();
        }

        private void Update() 
        {
            if (aIController.CanAttack())
            {
                GetComponentInChildren<Animator>().SetBool("isAttacking", true);
            }
            else
            {
                GetComponentInChildren<Animator>().SetBool("isAttacking", false);
            }
        }
    }
}