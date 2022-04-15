using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : Node
{       

    Lane currenlane;
    public SignalColor[] validateColors;
    [SerializeField]Lane lane1,lane2;
        public bool terminal=false;
     void Start()
     {
         lane=lane1;
     }
    public void Rotate(float direction)
    {
        if(direction==-1)
        {
            lane=lane1;
        }
        else if(direction==1)
        {
            lane=lane2;
        }
    }
    void Validate(Signal signal)
    {
        bool valid = false;
        foreach (SignalColor color in validateColors)
        {
            if (signal.Type == color)
            {
                valid = true;
                break;
            }
        }
        if (valid == false)
        {

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(terminal)
        {
        Destroy(other.gameObject);
        return;
        }

        if(other.gameObject.GetComponent<Signal>())
        {
            RedirectSignal(other.gameObject.GetComponent<Signal>());
        }

    }

}
[System.Serializable]
public class Lane
{
    public Transform emitter;
    public Transform nextreciever;
}
