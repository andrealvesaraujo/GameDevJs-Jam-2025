using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    private const int GAME_SCENE = 1;

    public void StartGame()
    {
        if (GameTimerController.gameTimerInstance != null){
            GameTimerController.gameTimerInstance.StartTimer();
        }
        SceneManager.LoadScene(GAME_SCENE);
    }
}
