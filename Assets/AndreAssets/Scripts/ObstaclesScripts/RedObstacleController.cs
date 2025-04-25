using UnityEngine;

public class RedObstacleController : MonoBehaviour
{
    private PlayerController player; // Reference to the Player
    [SerializeField] private bool startVisible = false;
    private bool isVisible = false;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Collider2D obstacleCollider; // Reference to the Collider2D
    [SerializeField] private int MIN_RESOURCES_TO_HIDE = 3;
    private AudioSource audioSource; // Reference to the AudioSource component
    private Animator anim;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obstacleCollider = GetComponent<Collider2D>(); // Get the Collider2D component
        player = FindObjectOfType<PlayerController>(); // Auto-find player
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>(); // Initializes the animator

        if (anim == null)
        {
            Debug.LogError("Animator component not found on this GameObject!");
        }
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
        }
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
            obstacleCollider.enabled = false;
            isVisible = true;
            anim.SetBool("toggle", false); // Changes the Animator condition "toggle" to true
        } else {
            obstacleCollider.enabled = true;
            isVisible = false;
            anim.SetBool("toggle", true); // Changes the Animator condition "toggle" to true
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is missing!");
            }           
        }
        else
        {
            Debug.LogWarning("PlayerController component not found on the colliding object.");
        }
    }

    void Update()
    {
        if (player == null) return;

        if(startVisible){
            if (player.recursoRed >= MIN_RESOURCES_TO_HIDE && isVisible)
            {
                obstacleCollider.enabled = true;
                isVisible = false;
                anim.SetBool("toggle", true); // Changes the Animator condition "toggle" to true

            }
            else if (player.recursoRed < MIN_RESOURCES_TO_HIDE && !isVisible)
            {
                obstacleCollider.enabled = false;
                isVisible = true;
                anim.SetBool("toggle", false); // Changes the Animator condition "toggle" to true

            }
        } else {
            if (player.recursoRed >= MIN_RESOURCES_TO_HIDE && !isVisible)
            {
                obstacleCollider.enabled = false;
                isVisible = true;
                anim.SetBool("toggle", false); // Changes the Animator condition "toggle" to true

            }
            else if (player.recursoRed < MIN_RESOURCES_TO_HIDE && isVisible)
            {
                obstacleCollider.enabled = true;
                isVisible = false;
                anim.SetBool("toggle", true); // Changes the Animator condition "toggle" to true
            }
        }
    }
}
