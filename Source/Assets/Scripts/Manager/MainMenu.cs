using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]GameObject menuScreen,levelScreen;
    public void LoadScene(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
