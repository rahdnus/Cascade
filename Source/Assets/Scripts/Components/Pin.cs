using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pin : Node
{       
    public System.Action onhit;
    public System.Action<int> onscore; 
    [SerializeField]Lane lane1,lane2;
    [SerializeField]SpriteRenderer left,right;

    public SpriteRenderer active;
    public bool terminal=false;
     void Awake()
     {
         lane=lane1;
        
         left.color=GameManager.Instance.SignalColorGenerator(lane1.validColor);
         right.color=GameManager.Instance.SignalColorGenerator(lane2.validColor);
         
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

            if (signal.Type == lane.validColor)
                valid = true;
       
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
    public SignalColor validColor;

}
