using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public SignalColor Type;
    Color color;

    Rigidbody2D rb;
    Vector2 moveDirection;
    [SerializeField] float moveSpeed=1;
    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    public void Init(SignalColor newType,Vector3 direction)
    {
        Type=newType;
        color=GameManager.Instance.SignalColorGenerator(Type);
        moveDirection=direction;
    }
    void FixedUpdate()
    {        
        rb.velocity=moveDirection*moveSpeed;
        // rb.MovePosition((transform.position+new Vector3(moveDirection.x,moveDirection.y,0))*moveSpeed);

    }

}
    public enum SignalColor
    {
        Undefined,Red,Lime,Cyan,Purple,Yellow
    }