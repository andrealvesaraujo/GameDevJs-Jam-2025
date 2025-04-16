using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.recursoRed++;
            Debug.Log("Oi red: " + player.recursoRed);
        }
        else
        {
            Debug.LogWarning("PlayerController component not found on the colliding object.");
        }
    }
}
