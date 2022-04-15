using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.MusicTheory;

[CreateAssetMenu(fileName="songItem",menuName="SO/songItem")]
public class SongItem : ScriptableObject
{
    public SignalColor[] signals;
    public AudioClip clip;
    [SerializeField] string midiPath;
    int counter=0;
public void ReadMIDIsong()
  {
     MidiFile midiFile=MidiFile.Read(Application.streamingAssetsPath+"/"+midiPath);
    var notes=midiFile.GetNotes();
    var array=new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
    notes.CopyTo(array,0);
    counter=0;
    signals=new SignalColor[array.GetLength(0)];
    Debug.Log(signals.GetLength(0));
    foreach(Melanchall.DryWetMidi.Interaction.Note note in array)
    {
        Debug.Log(note.NoteName);

        switch(note.NoteName)
        {
                case NoteName.A:
                    signals[counter] = SignalColor.Cyan;
                    break;
                case NoteName.B:
                    signals[counter] = SignalColor.Lime;
                    break;
                case NoteName.C:
                    signals[counter] = SignalColor.Purple;
                    break;
                case NoteName.D:
                    signals[counter] = SignalColor.Red;
                    break;
                case NoteName.E:
                    signals[counter] = SignalColor.Yellow;
                    break;

            }
        counter+=1;
    }
  }
}
