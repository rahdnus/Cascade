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

         TurnonLineRenderer();
     }
    public void Rotate(float direction)
    {
        if(direction==-1)
        {
            TurnoffLineRenderer();
            lane=lane1;
            TurnonLineRenderer();

        }
        else if(direction==1)
        {
            TurnoffLineRenderer();
            lane=lane2;
            TurnonLineRenderer();

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
    // void TurnonLineRenderer()
    // {

    //     if(lane.nextreciever==null)
    //      return;
    //     lane.emitter.GetComponent<LineRenderer>().enabled=true;

    //     lane.emitter.GetComponent<LineRenderer>().startWidth=0.2f;
    //     lane.emitter.GetComponent<LineRenderer>().endWidth=0.2f;

    //     lane.emitter.GetComponent<LineRenderer>().SetPosition(0,lane.emitter.position);
    //     lane.emitter.GetComponent<LineRenderer>().SetPosition(1,lane.nextreciever.position);
    // }
    // void TurnoffLineRenderer()
    // {
    //     lane.emitter.GetComponent<LineRenderer>().enabled=false;
    // }
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
