using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Valve.VR.InteractionSystem.Sample
{
    public class ReturnBall : MonoBehaviour
    {
        // Adjust the speed for the application.
        public float speed = 1.0f;
        private Transform target;
        public GameObject player;
        private Interactable interactable;


        void Start()
        {
            interactable = GetComponent<Interactable>();
        }

        void Update()
        {
            if (Input.GetKey("r"))
            {
                if (interactable != null && interactable.attachedToHand != null)
                {
                    transform.position = transform.position;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
                }
            }
        }
    }
}
