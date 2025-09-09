using UnityEngine;
using TMPro;

public class ResourceUIManager : MonoBehaviour
{

    public TextMeshProUGUI blueResourceText;
    public TextMeshProUGUI redResourceText;
    public TextMeshProUGUI gameTimerText;

    private PlayerController player;

    void Awake()
    {
        // Procura o Player na cena automaticamente
        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                Debug.LogWarning("Nenhum PlayerController encontrado na cena!");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (blueResourceText != null) blueResourceText.text = "Blue: 0";
        if (redResourceText != null) redResourceText.text = "Red: 0";
        if (gameTimerText != null) gameTimerText.text = "Time: 00:00";
    }


    void Update()
    {

        if (player != null && blueResourceText != null && redResourceText != null && GameTimerController.gameTimerInstance != null)
        {
            blueResourceText.text = $"Blue: {player.recursoBlue}";
            redResourceText.text = $"Red: {player.recursoRed}";
            gameTimerText.text = $"Time: {GameTimerController.gameTimerInstance.GetFormattedTime()}";
        }
    }

    public void OnActionButtonPressed()
    {
        if (player != null)
        {
            player.TouchEnergyGenerator();
        }
    }
    

}
