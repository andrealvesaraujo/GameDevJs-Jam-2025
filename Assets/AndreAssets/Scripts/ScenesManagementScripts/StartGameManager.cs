using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    private const int GAME_SCENE = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}
