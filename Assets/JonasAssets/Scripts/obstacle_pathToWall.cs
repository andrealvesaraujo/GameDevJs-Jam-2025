using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_pathToWall : MonoBehaviour
{
    public string color;
    public int level;
    private Animator anim;
    private BoxCollider2D col;

    public int TempResource = 0; // Só pra teste! troca ali em baixo isso daqui pelo recurso correspondente

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (color == "blue" && TempResource >= level){ // checa pela cor do recurso, e o compara com o requisito do objeto
            col.enabled = false;
            anim.SetBool("toggle", false); // Changes the Animator condition "toggle" to false
        }
        else if (color == "red" && TempResource >= level){
            col.enabled = false;   
            anim.SetBool("toggle", false); // Changes the Animator condition "toggle" to false
        }
        else{
            col.enabled = true;
            anim.SetBool("toggle", true); // Changes the Animator condition "toggle" to true
        }
    }
}
