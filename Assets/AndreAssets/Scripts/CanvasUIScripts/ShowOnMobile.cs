using UnityEngine;

public class ShowOnMobile : MonoBehaviour
{
    void Awake()
    {
        if (!Application.isMobilePlatform)
        {
            gameObject.SetActive(false);
        }
    }
}
