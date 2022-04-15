using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int score=0;
    public int lives=4;
    Pin[] pins;

    void Awake()
    {
        pins=Resources.FindObjectsOfTypeAll(typeof(Pin)) as Pin[];
        foreach(Pin pin in pins)
            pin.hit+=deductLife;
    }
    public void addScore(int points)
    {
        score+=points;
    }
    public void deductLife()
    {
        if(lives<0)
        {
            // Die
            return;
        }

        lives-=1;
        if(lives==0)
        {
            Debug.Log("Die");
            // Die
        }
        
    }
}
