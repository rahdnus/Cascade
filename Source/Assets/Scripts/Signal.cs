using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    SignalColor Type;
    Color color;

    Vector3 moveDirection;
    public void Init(SignalColor newType,Vector3 direction)
    {
        Type=newType;
        color=GameManager.Instance.SignalColorGenerator(Type);
        
    }
    void Update()
    {
        
    }
}
    public enum SignalColor
    {
        Undefined,Red,Lime,Cyan,Purple,Yellow
    }