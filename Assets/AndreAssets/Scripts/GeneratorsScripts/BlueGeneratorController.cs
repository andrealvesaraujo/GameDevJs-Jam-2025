using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGeneratorController : MonoBehaviour
{
    private bool isCollidingWithPlayer = false;
    private PlayerController player;

    private bool isActive = false;

    public Animator anim;

    private AudioSource audioSource; // Reference to the AudioSource component


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // Initializes the animator
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
        }
        if (anim == null)
        {
            Debug.LogError("Animator component not found on this GameObject!");
        }
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
                anim.SetBool("trigger", true); // Changes the Animator condition "trigger" to true
            }
            else
            {
                if (player.recursoBlue > 0)
                {
                    player.recursoBlue--;
                    Debug.Log("recursoBlue: " + player.recursoBlue);
                }
                isActive = false;
                anim.SetBool("trigger", false); // Changes the Animator condition "trigger" to false
            }
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is missing!");
            }
        }
    }
}
