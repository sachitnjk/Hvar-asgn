using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public int score;
    public static GameManager inst;

    public Text scoreText;

    public void AddScore(int value)
    {
       
        score += value;

        scoreText.text = "Score: " + score;
    }

    public void Awake() 
    {
        if(inst == null)
        {
            inst = this;
        }
        else 
        {
            Destroy(this);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
