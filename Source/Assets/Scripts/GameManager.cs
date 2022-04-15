using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance{
        get{
            if(instance==null)
                instance=new GameManager();
            return instance;
        }
    }
    public Color Red,Cyan,Lime,Purple,Yellow;

   public Color SignalColorGenerator(SignalColor color)
   {
       switch (color)
       {
           case SignalColor.Red:return Red;
           case SignalColor.Cyan:return Cyan;
           case SignalColor.Lime:return Lime;
           case SignalColor.Purple:return Purple;
           case SignalColor.Yellow:return Yellow;

           default:
            Debug.LogError("No such Color"+color.ToString());
            return Color.grey;
       }
   }
}
