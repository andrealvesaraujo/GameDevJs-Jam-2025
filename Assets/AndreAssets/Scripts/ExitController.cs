using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitController : MonoBehaviour
{
    public int requiredBlue = 1;
    public int requiredRed = 1;

    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if(player.recursoBlue == requiredBlue && player.recursoRed == requiredRed){

                Scene activeScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(activeScene.buildIndex+1);
                return;
            } else
            {
                // Play the beep error sound when requirements are not met
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
        
    }
}
