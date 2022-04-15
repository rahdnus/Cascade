using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{       
        Transform currentemitterpoint;
        Transform Emitterpoint1,Emitterpoint2;
        
    /* 
       
        Sprite signal1display;
        Sprite signal2display;

     */
    void Start()
    {

    }
    void Update()
    {

        if(!Input.anyKey)
            return;

        float horizontal=0;

        if(Input.GetKeyDown(KeyCode.LeftArrow)){ horizontal=-1;}
        else if(Input.GetKeyDown(KeyCode.RightArrow)){horizontal=1;}
        
        Rotate(horizontal);

        /*
        
         Rotate() 
         */
    }
    /*
    spawnnewSignal(Signal Reference)

    */
    void Rotate(float direction)
    {
        if(direction==-1)
        {
            currentemitterpoint=Emitterpoint1;
        }
        else if(direction==1)
        {
            currentemitterpoint=Emitterpoint2;
        }
    }
    void spawnNewSignal(Signal signal)
    {

    }   

}
