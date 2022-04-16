using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pin : Node
{       
    public System.Action onhit;
    public System.Action<int> onscore; 
    [SerializeField]Lane lane1,lane2;
    public bool terminal=false;
     void Awake()
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
    bool Validate(Signal signal)
    {
        bool valid = false;
        foreach (SignalColor color in lane.validateColors)
        {
            if (signal.Type == color)
            {
                valid = true;
                break;
            }
        }
        return valid;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.GetComponent<Signal>())
            return;
     
        if(terminal)
        {
        Destroy(other.gameObject);
        return;
        }

        Signal signal=other.gameObject.GetComponent<Signal>();
        if (Validate(signal))
        {
            RedirectSignal(signal);
            onscore(50);
            return;
        }
        Destroy(other.gameObject);
        onhit();
        Debug.Log("invalid");
    }

}
[System.Serializable]
public class Lane
{
    public Transform emitter;
    public Transform nextreciever;

    public SignalColor[] validateColors;

}
