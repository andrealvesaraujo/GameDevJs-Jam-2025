using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static GameTimerController gameTimerInstance;
    private float elapsedTime;
    private bool isRunning = false;
    
    void Start()
    {
        
    }

    void Awake()
    {
        if(gameTimerInstance == null){
            gameTimerInstance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }   
    }


    // Update is called once per frame
    void Update()
    {
        if(isRunning){
            elapsedTime+=Time.deltaTime;
        }
    }

    public void StartTimer(){
        elapsedTime = 0f;
        isRunning = true;
    }

    public void StopTimer(){
        isRunning = false;
    }

    public float GetTime(){
        return elapsedTime;
    }

    public string GetFormattedTime(){
        int minutes = Mathf.FloorToInt(elapsedTime/60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        return string.Format("{0:00}: {1:00}", minutes, seconds);
    }
}
