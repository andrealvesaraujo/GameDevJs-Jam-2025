using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGameManager : MonoBehaviour
{
    private const int START_SCENE = 0;
    public TextMeshProUGUI gameTimerText;

    public void Start()
    {
        if(GameTimerController.gameTimerInstance != null){
            GameTimerController.gameTimerInstance.StopTimer();
            gameTimerText.text = $"Total Time: {GameTimerController.gameTimerInstance.GetFormattedTime()}";
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(START_SCENE);
    }
}
