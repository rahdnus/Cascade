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
        currentPin.active.color=Color.white;

    }
    void Update()
    {
        if(GameManager.Instance.isPaused)
            return;
        
        if(!Input.anyKey)
            return;
            
        currentPin.active.color=Color.gray;
        
        if(Input.GetKeyDown(KeyCode.A) &&  pins[0]!=null)
        {
            currentPin=pins[0];
        }
        else 
        if(Input.GetKeyDown(KeyCode.S) && pins[1]!=null)
        {
            currentPin=pins[1];
        }
        else 
        if(Input.GetKeyDown(KeyCode.D) &&  pins[2]!=null)
        {
            currentPin=pins[2];
        }
            
        currentPin.active.color=Color.white;
        
        float horizontal=0;

        if(Input.GetKeyDown(KeyCode.LeftArrow)){ horizontal=-1;}
        else if(Input.GetKeyDown(KeyCode.RightArrow)){horizontal=1;}
        
        currentPin.Rotate(horizontal);
    }
}

