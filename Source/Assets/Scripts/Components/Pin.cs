using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pin : Node
{       

    Lane currenlane;

    public System.Action hit;
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
    bool Validate(Signal signal)
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
            return;
        }
        Destroy(other.gameObject);
        hit();
        Debug.Log("invalid");
    }

}
[System.Serializable]
public class Lane
{
    public Transform emitter;
    public Transform nextreciever;
}
