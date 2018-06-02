using UnityEngine;
using MidiJack;

public class NoteIndicator : MonoBehaviour
{
    public int noteNumber;

    void Update()
    {
        transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(noteNumber));
        bool pressed = MidiMaster.GetKeyDown(noteNumber);
        var color = pressed ? Color.red : Color.white;
        if(pressed)
        print(noteNumber);
        GetComponent<Renderer>().material.color = color;
    }
}
