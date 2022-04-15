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
        // Quaternion rotation= Quaternion.LookRotation(direction,Vector3.back);
        // signal.gameObject.transform.rotation=rotation;
        float angle=Mathf.Atan2(direction.x,direction.y)*Mathf.Rad2Deg;
        signal.gameObject.transform.rotation=Quaternion.AngleAxis(angle,Vector3.back);
        signal.Init(signal.Type,direction);
    }   
}
