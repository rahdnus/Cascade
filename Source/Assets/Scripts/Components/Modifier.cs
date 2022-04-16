using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : Node
{  
  [SerializeField] Pin pin;
  [SerializeField]SignalColor[] switchcolors;
  SignalColor mycolor;
  [SerializeField]SpriteRenderer myrenderer;
  void Start()
  {
    // switchcolors=pin.currentlane.validateColors;
    
    int index=Random.Range(0,switchcolors.Length);
    mycolor=switchcolors[index];
    myrenderer.color=GameManager.Instance.SignalColorGenerator(mycolor);
    TurnonLineRenderer();

  }
  void Switch(Signal signal)
  {
    signal.ChangeSignal(mycolor);
    int index=Random.Range(0,switchcolors.Length);
    mycolor=switchcolors[index];
    myrenderer.color=GameManager.Instance.SignalColorGenerator(mycolor);
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
