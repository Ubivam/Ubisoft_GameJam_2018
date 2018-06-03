using System;
using UnityEngine;

public class BarHandler : MonoBehaviour {

    private const int BAR_NUM = 1000;

    [SerializeField]
    private Color firstCol;

    [SerializeField]
    private Color secondCol;

    [SerializeField]
    private GameObject bar;

    private GameObject[] barArray;

    public float scaleIntensity = 5;
    public int scaleIndex = 10;

    [SerializeField]
    private float peekMul = 5.0f;

    [SerializeField]
    private float sigmaSquared = 1;

    [SerializeField]
    private Rigidbody player;

    Rigidbody[] r;

    Vector3[] initPos;

    public static bool asd = false;

    long startTime;

    void Start() {
        float camHeight = 2 * Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        float barWidth = camWidth / BAR_NUM;
        bar.transform.localScale = new Vector3(
                barWidth,
                bar.transform.localScale.y,
                bar.transform.localScale.z);
        barArray = new GameObject[BAR_NUM];

        initPos = new Vector3[BAR_NUM];


        for (int i = 0; i < BAR_NUM; ++i) {
            Vector3 posVec = new Vector3(-camWidth / 2 + i * barWidth, -camHeight / 2, 0.0f);
            barArray[i] = Instantiate(bar, posVec, Quaternion.identity) as GameObject;
            barArray[i].transform.parent = this.gameObject.transform;

            float colorFactor = i / BAR_NUM;
            barArray[i].GetComponentInChildren<Renderer>().material.color = firstCol;

            initPos[i] = barArray[i].transform.position;
        }

        r = GetComponentsInChildren<Rigidbody>();
        
    }

    void Update()
    {

      /* if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            asd = true;
            scaleIndex = 0 * (BAR_NUM / 9);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scaleIndex = 1 * (BAR_NUM / 9);
            asd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            scaleIndex = 2 * (BAR_NUM / 9);
            asd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            scaleIndex = 3 * (BAR_NUM / 9);
            asd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            scaleIndex = 4 * (BAR_NUM / 9);
            asd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            scaleIndex = 5 * (BAR_NUM / 9);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            scaleIndex = 6 * (BAR_NUM / 9);
            asd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            scaleIndex = 7 * (BAR_NUM / 9);
            asd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            scaleIndex = 8 * (BAR_NUM / 9);
            asd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            scaleIndex = 9 * (BAR_NUM / 9);
            asd = true;
        }
        */
        bool[] input = InputManager.Instance.GetInputsAndClear();
        for (int i = 0; i < 49; i++)
        {
            if (input[i])
            {
                scaleIndex = scaleIndex = (i) * (BAR_NUM / 49);
            }
        }

    }

    private void FixedUpdate()
    {
        for (int i = 0; i < BAR_NUM; ++i)
        {
            float distance = Mathf.Abs(i - scaleIndex) + 0.1f;
            float factor = 1 / distance;
            factor = (1 / (Mathf.Sqrt(2 * Mathf.PI * sigmaSquared))) * Mathf.Exp(Mathf.Pow(distance, 2) / (-2 * sigmaSquared)) * peekMul;

            /*if (barArray[i].transform.position.y + 0.1 >= initPos[i].y + factor)
            {
                asd = false;
            }

            if (!asd)
            {
                factor = 0;
            }*/

            r[i].MovePosition(new Vector3(
                barArray[i].transform.position.x,
                Mathf.Lerp(barArray[i].transform.position.y,
                initPos[i].y + factor,
                Time.deltaTime * 10),
                barArray[i].transform.position.z));
        }
    }
}
