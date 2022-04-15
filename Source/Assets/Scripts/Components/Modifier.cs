using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : Node
{  

   void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.GetComponent<Signal>())
        {
            RedirectSignal(other.gameObject.GetComponent<Signal>());
        }

    }
}
