using UnityEngine;

public class BlueObstacleController : MonoBehaviour
{
    public PlayerController player; // Reference to the Player
    private bool isVisible = true;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Collider2D obstacleCollider; // Reference to the Collider2D

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obstacleCollider = GetComponent<Collider2D>(); // Get the Collider2D component
        
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on BlueObstacle!");
        }
        if (obstacleCollider == null)
        {
            Debug.LogError("Collider2D not found on BlueObstacle!");
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
