using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager Instance;


    bool[] keyboard_input;

    public int index;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
        keyboard_input = new bool[50];
    }

    void Update() {
        for (int i = 24; i <= 72; i++)
        {
            keyboard_input[i-24] = MidiJack.MidiMaster.GetKeyDown(i);
            if (keyboard_input[i-24])
            {
                BarHandler.asd = true;
                Debug.Log(i);
            }
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
