using UnityEngine;

public class BlueObstacleController : MonoBehaviour
{
    private PlayerController player; // Reference to the Player
    private bool isVisible = true;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Collider2D obstacleCollider; // Reference to the Collider2D

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obstacleCollider = GetComponent<Collider2D>(); // Get the Collider2D component
        player = FindObjectOfType<PlayerController>(); // Auto-find player
       
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on RedObstacle!");
        }
        if (obstacleCollider == null)
        {
            Debug.LogError("Collider2D not found on RedObstacle!");
        }
        if (player == null)
        {
            Debug.LogError("PlayerController not found in the scene!");
        }
        
        spriteRenderer.enabled = true;
        obstacleCollider.enabled = true;
    }

    void Update()
    {
        if (player == null) return;

        if (player.recursoBlue >= 1 && isVisible)
        {
            spriteRenderer.enabled = false;
            obstacleCollider.enabled = false;
            isVisible = false;
        }
        else if (player.recursoBlue < 1 && !isVisible)
        {
            spriteRenderer.enabled = true;
            obstacleCollider.enabled = true;
            isVisible = true;
        }
    }
}
