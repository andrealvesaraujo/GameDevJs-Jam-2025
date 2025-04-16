using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGenerator : MonoBehaviour
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
            player.recursoBlue++;
            Debug.Log("Oi blue: " + player.recursoBlue);
        }
        else
        {
            Debug.LogWarning("PlayerController component not found on the colliding object.");
        }
    }
}
