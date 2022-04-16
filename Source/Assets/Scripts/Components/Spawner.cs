using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] SongItem item;
    [SerializeField] SignalColor[] colors;
    [SerializeField] Lane lane;
    [SerializeField] GameObject signalPrefab;
    [SerializeField] float spawndelay=0.5f;
    int counter=0;
    float timer=0f;
    void Start()
    {   
        item.ReadMIDIsong();
    }
    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            timer += Time.deltaTime;
            if (timer > spawndelay)
            {
                Spawn(item.signals[counter], lane.emitter.position, lane);
                timer = 0;
                counter += 1;
            }
        }
    }
    public void Spawn(SignalColor color,Vector3 position,Lane lane)
    {
        GameObject signal=Instantiate(signalPrefab,position,Quaternion.identity);
        
        Vector3 direction=(lane.nextreciever.position-lane.emitter.position).normalized;

        signal.GetComponent<Signal>().Init(color,direction);
    }
}
