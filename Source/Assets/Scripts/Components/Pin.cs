using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{       
        Lane currentlane;
        [SerializeField]Lane lane1,lane2;
        public bool terminal=false;
        LineRenderer linerenderer;
    /* 
        Sprite signal1display;
        Sprite signal2display;
     */
     void Start()
     {
         currentlane=lane1;
     }
    public void Rotate(float direction)
    {
        if(direction==-1)
        {
            currentlane=lane1;
        }
        else if(direction==1)
        {
            currentlane=lane2;
        }
    }
    void RedirectSignal(Signal signal)
    {
        Vector3 direction=(currentlane.nextreciever.position-currentlane.emitter.position).normalized;
        signal.gameObject.transform.position=currentlane.emitter.position;
        // Quaternion rotation= Quaternion.LookRotation(direction,Vector3.back);
        // signal.gameObject.transform.rotation=rotation;
        float angle=Mathf.Atan2(direction.x,direction.y)*Mathf.Rad2Deg;
        signal.gameObject.transform.rotation=Quaternion.AngleAxis(angle,Vector3.back);
        signal.Init(signal.Type,direction);
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
            // Destroy(other.gameObject);
        }

    }

}
[System.Serializable]
public class Lane
{
    public Transform emitter;
    public Transform nextreciever;
}
