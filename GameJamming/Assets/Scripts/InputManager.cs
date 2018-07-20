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
      
        
        keyboard_input[0] = Input.GetKeyDown(KeyCode.Q);
        keyboard_input[4] = Input.GetKeyDown(KeyCode.W);
        keyboard_input[8] = Input.GetKeyDown(KeyCode.E);
        keyboard_input[12] = Input.GetKeyDown(KeyCode.R);
        keyboard_input[16] = Input.GetKeyDown(KeyCode.T);
        keyboard_input[20] = Input.GetKeyDown(KeyCode.Y);
        keyboard_input[24] = Input.GetKeyDown(KeyCode.U);
        keyboard_input[28] = Input.GetKeyDown(KeyCode.I);
        keyboard_input[32] = Input.GetKeyDown(KeyCode.O);
        keyboard_input[36] = Input.GetKeyDown(KeyCode.P);
        keyboard_input[40] = Input.GetKeyDown(KeyCode.LeftBracket);
        keyboard_input[44] = Input.GetKeyDown(KeyCode.RightBracket);
        keyboard_input[48] = Input.GetKeyDown(KeyCode.Backslash);
        /*for (int i = OFFEST; i <= OFFEST+49; i++)
        {
            keyboard_input[i-OFFEST] = MidiJack.MidiMaster.GetKeyDown(i);
            if (keyboard_input[i- OFFEST])
            {
                BarHandler.asd = true;
                Debug.Log(i);
            }
        }*/
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
