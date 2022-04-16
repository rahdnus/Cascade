using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Lane lane;
    protected LineRenderer linerenderer;
    protected void RedirectSignal(Signal signal)
    {
        Vector3 direction=(lane.nextreciever.position-lane.emitter.position).normalized;
        signal.gameObject.transform.position=lane.emitter.position;

        float angle=Mathf.Atan2(direction.x,direction.y)*Mathf.Rad2Deg;
        
        signal.gameObject.transform.rotation=Quaternion.AngleAxis(angle,Vector3.back);

        signal.Init(signal.Type,direction);
    }   
    protected void TurnonLineRenderer()
    {

        if(lane.nextreciever==null)
         return;
        lane.emitter.GetComponent<LineRenderer>().enabled=true;

        lane.emitter.GetComponent<LineRenderer>().startWidth=0.2f;
        lane.emitter.GetComponent<LineRenderer>().endWidth=0.2f;

        lane.emitter.GetComponent<LineRenderer>().SetPosition(0,lane.emitter.position);
        lane.emitter.GetComponent<LineRenderer>().SetPosition(1,lane.nextreciever.position);
    }
    protected void TurnoffLineRenderer()
    {
        lane.emitter.GetComponent<LineRenderer>().enabled=false;
    }

}
