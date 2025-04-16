using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueObstacleController : MonoBehaviour
{
    public PlayerController player; // Reference to the Player
    private bool isVisible = false;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on BlueObstacle!");
        }
        spriteRenderer.enabled = false; // Start hidden
    }

    void Update()
    {
        if (player == null) return; // Prevent null reference errors

        if (player.recursoBlue >= 3 && !isVisible)
        {
            Debug.Log("Ativou");
            spriteRenderer.enabled = true;
            isVisible = true;
        }
        else if (player.recursoBlue < 3 && isVisible)
        {
            Debug.Log("Desativou");
            spriteRenderer.enabled = false;
            isVisible = false;
        }
    }
}
