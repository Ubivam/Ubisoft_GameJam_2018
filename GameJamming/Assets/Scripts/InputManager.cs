using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;

    }


    bool[] keyboard_input;


    // Update is called once per frame
    void Update() {
        for (int i = 38; i <= 84; i++)
        {
            keyboard_input[i - 38] = MidiJack.MidiMaster.GetKeyDown(i);
        } 
	}

    public bool[] GetInputsAndClear()
    {
        bool[] ret = keyboard_input.Clone() as bool[];

        for (int i = 0; i < keyboard_input.Length; i++)
            keyboard_input[i] = false;

        return ret;
    }
}
