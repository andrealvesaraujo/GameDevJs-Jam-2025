using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGeneratorController : MonoBehaviour, IGenerator
{
    
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

    public void ToggleEnergy(PlayerController player)
    {

        if (player == null) return;

        if (!isActive)
        {
            player.recursoRed++;
            Debug.Log("recursoRed: " + player.recursoRed);
            isActive = true;
            anim.SetBool("trigger", true); // Changes the Animator condition "trigger" to true
        }
        else
        {
            if (player.recursoRed > 0)
            {
                player.recursoRed--;
                Debug.Log("recursoRed: " + player.recursoRed);
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
