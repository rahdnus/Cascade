using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    [SerializeField]Text ScoreUI;
    public int nextSceneBuildIndex;
    [SerializeField]GameObject DeathScreen,PauseScreen,SuccessScreen,onScreen;
    public int score=0;
    public int lives=4;
    Pin[] pins;

    void Awake()
    {
        pins=Resources.FindObjectsOfTypeAll(typeof(Pin)) as Pin[];
        foreach(Pin pin in pins)
        {
            pin.onhit+=deductLife;
            pin.onscore+=addScore;
        }
        PauseScreen.SetActive(false);
        DeathScreen.SetActive(false);
        SuccessScreen.SetActive(false);
    }
    public void addScore(int points)
    {
        score+=points;
        ScoreUI.text=score.ToString("00000000");

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
            displayFailure();
        }
        
    }
    public void LoadScene(int index)
    {
        GameManager.Instance.isPaused=false;
        SceneManager.LoadScene(index);

    }
    public void displaySuccess()
    {
        SuccessScreen.SetActive(true);
        onScreen.SetActive(false);
        GameManager.Instance.isPaused=true;
        //Display Score as well
    }
    public void displayFailure()
    {
        DeathScreen.SetActive(true);
        onScreen.SetActive(false);
        GameManager.Instance.isPaused=true;
        //Display Score as well
        
    }
    public void togglePause(bool state)
    {
        PauseScreen.SetActive(state);
        onScreen.SetActive(!state);
        GameManager.Instance.isPaused=state;
    }
}
