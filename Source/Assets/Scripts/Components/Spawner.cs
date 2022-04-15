using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] Transform defaultPos;
    [SerializeField] GameObject signalPrefab;
    public void Spawn(Vector3 position,Lane lane)
    {
        int typeindex=Random.Range(0,5);
        GameObject signal=Instantiate(signalPrefab,position,Quaternion.identity);
        
        SignalColor color=Utils.Instance.indextoSignalType(typeindex);
        Vector3 direction=(lane.nextreciever.position-lane.emitter.position).normalized;
        signal.GetComponent<Signal>().Init(color,direction);
    }
}
