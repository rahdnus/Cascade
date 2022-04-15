using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{       
        Transform currentemitterpoint,nextdestinationPoint;
        [SerializeField]Lane lane1,lane2;
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
    }
    void Rotate(float direction)
    {
        if(direction==-1)
        {
            currentemitterpoint=lane1.emitter;
        }
        else if(direction==1)
        {
            currentemitterpoint=lane2.emitter;
        }
    }
    void spawnNewSignal(Signal signal)
    {

    }   

}
[System.Serializable]
public class Lane
{
    public Transform emitter;
    public Transform nextreciever;
}
