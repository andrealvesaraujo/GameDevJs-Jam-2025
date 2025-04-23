using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGameManager : MonoBehaviour
{
    private const int START_SCENE = 0;

    public void EndGame()
    {
        SceneManager.LoadScene(START_SCENE);
    }
}
