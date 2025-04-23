using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGameManager : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
