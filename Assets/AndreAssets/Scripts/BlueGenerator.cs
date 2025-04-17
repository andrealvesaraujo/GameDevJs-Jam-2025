    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BlueGenerator : MonoBehaviour
    {
        private bool isCollidingWithPlayer = false;
        private PlayerController player;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Aperta Z para aumentar. E X para diminuir valor do recurso");
                isCollidingWithPlayer = true;
                player = other.gameObject.GetComponent<PlayerController>();
            }
            else
            {
                Debug.LogWarning("PlayerController component not found on the colliding object.");
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                isCollidingWithPlayer = false;
                player = null;
            }
        }

        private void Update()
        {
            if (!isCollidingWithPlayer || player == null) return;

            if (isCollidingWithPlayer && player != null)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    player.recursoBlue++;
                    Debug.Log("recursoBlue: " + player.recursoBlue);
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    player.recursoBlue--;
                    Debug.Log("recursoBlue: " + player.recursoBlue);
                }
            }
        }
    }
