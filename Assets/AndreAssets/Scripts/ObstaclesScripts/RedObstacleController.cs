using UnityEngine;

public class RedObstacleController : MonoBehaviour
{
    private PlayerController player; // Reference to the Player
    [SerializeField] private bool startVisible = true;
    private bool isVisible = true;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Collider2D obstacleCollider; // Reference to the Collider2D

    [SerializeField] private int MIN_RESOURCES_TO_HIDE = 3;

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

        if(startVisible){
            spriteRenderer.enabled = true;
            obstacleCollider.enabled = true;
            isVisible = true;
        } else {
            spriteRenderer.enabled = false;
            obstacleCollider.enabled = false;
            isVisible = false;
        }
    }

    void Update()
    {
        if (player == null) return; // Prevent null reference errors

        if(startVisible){
            if (player.recursoRed >= MIN_RESOURCES_TO_HIDE && isVisible)
            {
                spriteRenderer.enabled = false;
                obstacleCollider.enabled = false;
                isVisible = false;
            }
            else if (player.recursoRed < MIN_RESOURCES_TO_HIDE && !isVisible)
            {
                spriteRenderer.enabled = true;
                obstacleCollider.enabled = true;
                isVisible = true;
            }
        } else {
            if (player.recursoRed >= MIN_RESOURCES_TO_HIDE && !isVisible)
            {
                spriteRenderer.enabled = true;
                obstacleCollider.enabled = true;
                isVisible = true;
            }
            else if (player.recursoRed < MIN_RESOURCES_TO_HIDE && isVisible)
            {
                spriteRenderer.enabled = false;
                obstacleCollider.enabled = false;
                isVisible = false;
            }
        }
    }
}
