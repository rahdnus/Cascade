using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : Node
{  
  [SerializeField] Pin pin;
  SignalColor[] switchcolors;
  SignalColor mycolor;

  void Start()
  {
    switchcolors=pin.validateColors;
    int index=Random.Range(0,switchcolors.Length);
    mycolor=switchcolors[index];
  }
  void Switch(Signal signal)
  {
    signal.ChangeSignal(mycolor);
    int index=Random.Range(0,switchcolors.Length);
    mycolor=switchcolors[index];
    GetComponent<SpriteRenderer>().color=GameManager.Instance.SignalColorGenerator(mycolor);
  }
  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.GetComponent<Signal>())
    {
      RedirectSignal(other.gameObject.GetComponent<Signal>());
      Switch(other.gameObject.GetComponent<Signal>());
    }
  }
}
