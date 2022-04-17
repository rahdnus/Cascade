using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public SongItem item;
    [SerializeField] SignalColor[] colors;
    [SerializeField] Lane lane;
    [SerializeField] GameObject signalPrefab;
    [SerializeField] float spawndelay=0.5f;
    // int counter=0;
    float timer=0f;
    [SerializeField]float startdelay=2f;

    float startcounter=0;
    void Start()
    {   
        // item.ReadMIDIsong();
    }
    void Update()
    {


        if (!GameManager.Instance.isPaused)
        {
            startcounter+=Time.deltaTime;
            if(startcounter>startdelay)
            {
                timer += Time.deltaTime;
            if (timer > spawndelay)
            {
                int index=Random.Range(0,colors.Length);
                Spawn(colors[index],lane.emitter.position,lane);
                timer = 0;
            }
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
