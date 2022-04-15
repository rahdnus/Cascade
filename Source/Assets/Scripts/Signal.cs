using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    SignalColor Type;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color=GameManager.Instance.SignalColorGenerator(Type);
    }
    void Update()
    {
        //move in a path
    }
}
    public enum SignalColor
    {
        Red,Lime,Cyan,Purple,Yellow
    }