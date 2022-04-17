using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    [SerializeField]AudioSource audioSource;
    [Space(10)]  
    [SerializeField]AudioClip hurt;      
    [SerializeField]Text ScoreUI,totalScoreDeath,totalScoreSuccess;
    public int nextSceneBuildIndex;
    [SerializeField]GameObject DeathScreen,PauseScreen,SuccessScreen,onScreen,RedScreen;
    public int score=0;
    public int lives=4;
    Pin[] pins;
    [SerializeField]Spawner spawner;
    float clipLength,timer;
    float spawnstoptime;
    void Awake()
    {
        GameManager.Instance.isPaused=false;
        // spawner=GameObject.FindObjectOfType(typeof(Spawner)) as Spawner;   
        if(spawner!=null)
        {    
        
            audioSource.clip=spawner.item.clip;
            clipLength=audioSource.clip.length;
            Debug.Log("CL:"+clipLength);
            spawnstoptime=clipLength-3f;
            audioSource.Play();
        
        }     
    
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
    public void Update()
    {
        Debug.Log(GameManager.Instance.isPaused);
        if(GameManager.Instance.isPaused)
        return;

        timer+=Time.deltaTime;
        if(timer>spawnstoptime)
        {
            spawner.enabled=false;
        }
        if(timer>clipLength)
        {
            displaySuccess();
        }
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
        RedScreen.GetComponent<Animator>().Play("Error");
        AudioSource.PlayClipAtPoint(hurt,spawner.gameObject.transform.position);
        if(lives==0)
        {
            Debug.Log("Die");
            displayDeath();
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
        totalScoreSuccess.text=score.ToString("00000000");
        //Display Score as well
    }
    public void displayDeath()
    {
        DeathScreen.SetActive(true);
        onScreen.SetActive(false);
        GameManager.Instance.isPaused=true;
        totalScoreDeath.text=score.ToString("00000000");
        //Display Score as well
        
    }
    public void togglePause(bool state)
    {
        PauseScreen.SetActive(state);
        onScreen.SetActive(!state);
        GameManager.Instance.isPaused=state;
    }
}
