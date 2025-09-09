using UnityEngine;

public class ShowOnMobile : MonoBehaviour
{
    void Awake()
    {
        // TODO: Mostrar quando tiver joystick mobile
        // Se não for mobile, desativa
        // if (!Application.isMobilePlatform)
        // {
        gameObject.SetActive(false);
        // }
    }
}
