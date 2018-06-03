using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager Instance;


    bool[] keyboard_input;

    public int index;

    public static int OFFEST = 36;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
        keyboard_input = new bool[50];
    }

    void Update() {
        for (int i = OFFEST; i <= OFFEST+49; i++)
        {
            keyboard_input[i-OFFEST] = MidiJack.MidiMaster.GetKeyDown(i);
            if (keyboard_input[i- OFFEST])
            {
                BarHandler.asd = true;
                Debug.Log(i);
            }
        }
	}

    public bool[] GetInputsAndClear()
    {
        bool[] ret = keyboard_input.Clone() as bool[];

        //for (int i = 0; i < keyboard_input.Length; i++)
        //    keyboard_input[i] = false;

        return ret;
    }

    public bool[] GetInputs()
    {
        bool[] ret = keyboard_input.Clone() as bool[];

        return ret;
    }
}
