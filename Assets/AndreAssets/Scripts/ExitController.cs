using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitController : MonoBehaviour
{
    public int requiredBlue = 1;
    public int requiredRed = 1;

    private AudioSource audioSource; // Reference to the AudioSource component

    private PlayerController player; // Reference to the Player

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerController>(); // Auto-find player

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
        }
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject!");
        }
        if (player == null)
        {
            Debug.LogError("PlayerController not found in the scene!");
        }

        spriteRenderer.color = Color.white;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.recursoBlue == requiredBlue && player.recursoRed == requiredRed)
            {
                Scene activeScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(activeScene.buildIndex + 1);
                return;
            }
            else
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
        }
        else
        {
            Debug.LogWarning("PlayerController component not found on the colliding object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        if (player.recursoBlue == requiredBlue && player.recursoRed == requiredRed)
        {
            spriteRenderer.color = Color.black;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
