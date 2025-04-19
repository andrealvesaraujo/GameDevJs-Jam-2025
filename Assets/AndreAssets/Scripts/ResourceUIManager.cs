using UnityEngine;
using TMPro;

public class ResourceUIManager : MonoBehaviour
{

    public TextMeshProUGUI blueResourceText;
    public TextMeshProUGUI redResourceText;
    public PlayerController player;

    
    // Start is called before the first frame update
    void Start()
    {
        if (blueResourceText != null) blueResourceText.text = "Blue: 0";
        if (redResourceText != null) redResourceText.text = "Red: 0";
    }


    void Update()
    {

        if (player != null && blueResourceText != null && redResourceText != null) {
            blueResourceText.text = $"Blue: {player.recursoBlue}";
            redResourceText.text = $"Red: {player.recursoRed}";
        }
    }

}
