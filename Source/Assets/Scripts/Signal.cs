using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public SignalColor Type;
    Rigidbody2D rb;
    Vector2 moveDirection;
    [SerializeField] float moveSpeed=1;
    float currentSpeed;
    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        currentSpeed=moveSpeed;

    }
    public void Init(SignalColor newType,Vector3 direction)
    {
        Type=newType;
        GetComponent<SpriteRenderer>().color=GameManager.Instance.SignalColorGenerator(Type);

        moveDirection=direction;
    }
    void Update()
    {
        if(GameManager.Instance.isPaused)
        {
            currentSpeed=0;
        }
        else
        {
            currentSpeed=moveSpeed;
        }
    }
    void FixedUpdate()
    {        
            rb.velocity=moveDirection*currentSpeed;

        // rb.MovePosition((transform.position+new Vector3(moveDirection.x,moveDirection.y,0))*moveSpeed);
    }
    public void ChangeSignal(SignalColor signaltype)
    {
        Type=signaltype;
        ChangeColor(GameManager.Instance.SignalColorGenerator(Type));
    }
    void ChangeColor(Color color)
    {
        GetComponent<SpriteRenderer>().color=color;
    }
}
    public enum SignalColor
    {
        Undefined,Red,Lime,Cyan,Purple,Yellow
    }