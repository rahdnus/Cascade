using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controller : MonoBehaviour
{
    [SerializeField] Pin[] pins;
    Pin currentPin;
    void Start()
    {
        currentPin=pins[0];
    }
    void Update()
    {
        if(GameManager.Instance.isPaused)
            return;
        
        if(!Input.anyKey)
            return;
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            currentPin=pins[0];
        }
        else 
        if(Input.GetKeyDown(KeyCode.S))
        {
            currentPin=pins[1];
        }
        else 
        if(Input.GetKeyDown(KeyCode.D))
        {
            currentPin=pins[2];
        }
        
        float horizontal=0;

        if(Input.GetKeyDown(KeyCode.LeftArrow)){ horizontal=-1;}
        else if(Input.GetKeyDown(KeyCode.RightArrow)){horizontal=1;}
        
        currentPin.Rotate(horizontal);
    }
}

