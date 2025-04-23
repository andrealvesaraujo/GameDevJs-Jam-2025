using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    public TextMeshProUGUI redPanelText;
    public TextMeshProUGUI bluePanelText;
    public ExitController exitDoor;

    
    // Start is called before the first frame update
    void Start()
    {
        if (bluePanelText != null) bluePanelText.text = "0";
        if (redPanelText != null) redPanelText.text = "0";
    }


    void Update()
    {

        if (exitDoor != null && bluePanelText != null && redPanelText != null) {
            bluePanelText.text = $"{exitDoor.requiredBlue}";
            redPanelText.text = $"{exitDoor.requiredRed}";
        }
    }
}
