using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    private static GameManager instance;
    public static GameManager Instance{
        get{
            if(instance==null)
                instance=new GameManager();
            return instance;
        }
    }
    public Color Red=Color.red,Cyan=Color.blue,Lime=Color.green,Purple=Color.magenta,Yellow=Color.yellow;

    GameObject signalPrefab;

    public GameManager()
    {
        signalPrefab=Resources.Load("Prefabs/FirstPass/Signal") as GameObject;

    }
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
