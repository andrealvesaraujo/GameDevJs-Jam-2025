using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGeneratorController : MonoBehaviour
{
    private bool isCollidingWithPlayer = false;
    private PlayerController player;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Press Space to toggle the blue resource value");
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isActive)
            {
                player.recursoBlue++;
                Debug.Log("recursoBlue: " + player.recursoBlue);
                isActive = true;
            }
            else
            {
                if (player.recursoBlue > 0)
                {
                    player.recursoBlue--;
                    Debug.Log("recursoBlue: " + player.recursoBlue);
                }
                isActive = false;
            }
        }
    }
}
