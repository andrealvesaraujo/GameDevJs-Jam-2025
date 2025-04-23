using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int requiredBlue = 5;
    [SerializeField] private int requiredRed = 5;

    private const int ENDING_SCENE = 2;


    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log($"Recurso blue: {player.recursoBlue} e red: {player.recursoRed}");

            if(player.recursoBlue >= requiredBlue && player.recursoRed >= requiredRed){

                Debug.Log("Ganhou o jogo");
                SceneManager.LoadScene(ENDING_SCENE);
                return;
            }
            
            Debug.Log($"Ainda não ganhou o jogo. Precisa de {requiredBlue} blue e {requiredRed} red.");
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
