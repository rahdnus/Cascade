using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] SignalColor[] colors;
    [SerializeField] Lane lane;
    [SerializeField] GameObject signalPrefab;

    // TEMP
    float counter=0,timer=1f;
    void Update()
    {
        counter+=Time.deltaTime;
        if(counter>timer)
        {
            Spawn(lane.emitter.position,lane);
            counter=0;
        }
    }
    public void Spawn(Vector3 position,Lane lane)
    {
        int typeindex=Random.Range(0,colors.Length);
        GameObject signal=Instantiate(signalPrefab,position,Quaternion.identity);
        
        SignalColor color=colors[typeindex];
        Vector3 direction=(lane.nextreciever.position-lane.emitter.position).normalized;

        signal.GetComponent<Signal>().Init(color,direction);
    }
}
