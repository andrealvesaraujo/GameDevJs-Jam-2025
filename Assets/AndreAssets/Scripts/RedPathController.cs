using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPathController : MonoBehaviour
{
    public PlayerController player; // Reference to the Player
    private bool isVisible = true;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Collider2D obstacleCollider; // Reference to the Collider2D

    // Start is called before the first frame update
     void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obstacleCollider = GetComponent<Collider2D>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on RedPath!");
        }
        if (obstacleCollider == null)
        {
            Debug.LogError("Collider2D not found on RedPath!");
        }

        spriteRenderer.enabled = true; // Start hidden
        obstacleCollider.enabled = true; // Start with collider disabled
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return; // Prevent null reference errors

        if (player.recursoRed >= 5 && isVisible)
        {
            Debug.Log("Sumiu caminho");
            spriteRenderer.enabled = false;
            obstacleCollider.enabled = false; 
            isVisible = false;
        }
        else if (player.recursoRed < 5 && !isVisible)
        {
            Debug.Log("Apareceu caminho");
            spriteRenderer.enabled = true;
            obstacleCollider.enabled = true; 
            isVisible = true;
        }
    }
}
