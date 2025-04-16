using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedObstacleController : MonoBehaviour
{
    public PlayerController player; // Reference to the Player
    private bool isVisible = false;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Collider2D obstacleCollider; // Reference to the Collider2D

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obstacleCollider = GetComponent<Collider2D>(); // Get the Collider2D component

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on RedObstacle!");
        }
        if (obstacleCollider == null)
        {
            Debug.LogError("Collider2D not found on RedObstacle!");
        }

        spriteRenderer.enabled = false; // Start hidden
        obstacleCollider.enabled = false; // Start with collider disabled
    }

    void Update()
    {
        if (player == null) return; // Prevent null reference errors

        if (player.recursoRed >= 3 && !isVisible)
        {
            Debug.Log("Ativou");
            spriteRenderer.enabled = true;
            obstacleCollider.enabled = true; // Enable collider when visible
            isVisible = true;
        }
        else if (player.recursoRed < 3 && isVisible)
        {
            Debug.Log("Desativou");
            spriteRenderer.enabled = false;
            obstacleCollider.enabled = false; // Disable collider when hidden
            isVisible = false;
        }
    }
}
