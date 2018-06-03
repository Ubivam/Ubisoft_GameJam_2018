
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    private AudioSource source;

    [Range (0f, 1f)]
    public float volume=0.7f;

    [Range(0.5f,1.5f)]
    public float pitch = 1f;
    



    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}



public class AudioManager : MonoBehaviour {
    [SerializeField]
    Sound[] sounds;
    Sound[] toBePlayed;
    Time time;
    [SerializeField]
    int treshold;
    int[] timePressed;
    public static AudioManager instance;
    int flag;

    public int getMaxValFromArray()
    {
        int toBeReturned = 0;
        Scene objpravi = SceneManager.GetActiveScene();
        Scene level1 = SceneManager.GetSceneByName("Level 1");
        Scene level2 = SceneManager.GetSceneByName("Level 2");


        int currLevel = 0;
        if (objpravi.Equals(level2))
            currLevel = 2;
        if (objpravi.Equals(level1))
            currLevel = 1;


        int startingIndex = 0;
        int lastIndex = 0;


        switch (currLevel)
        {
            case 1:
                startingIndex = 1;
                lastIndex = 4;
                break;
            case 2:
                startingIndex = 5;
                lastIndex = 9;
                break;
            default:
            
                break;
        }



        toBeReturned = startingIndex;
        int maxVal = timePressed[toBeReturned];


        for(int i=startingIndex;i<lastIndex+1;i++)
        {
            if(timePressed[i]>maxVal && timePressed[i]>=treshold)
            {
                maxVal = timePressed[i];
                toBeReturned = i;
            }
        }
        if (toBeReturned == startingIndex && timePressed[startingIndex] < treshold)
        {
            for(int i = startingIndex; i < lastIndex + 1; i++)
            {
                timePressed[i] = 0;
            }
            return 0;
        }

        timePressed[toBeReturned] = 0;




        return toBeReturned;
    }
    
    IEnumerator WaitForSeconds(float seconds)
    {
       
        yield return new WaitForSeconds(seconds);
        Scene objpravi = SceneManager.GetActiveScene();
        Scene level1 = SceneManager.GetSceneByName("Level 1");
        Scene level2 = SceneManager.GetSceneByName("Level 2");

        int songNum;
        int currLevel = 0;
        if (objpravi.Equals(level2))
            currLevel = 2;
        if (objpravi.Equals(level1))
            currLevel = 1;


        int startingIndex = 0;
        int lastIndex = 0;


        switch (currLevel)
        {
            case 1:
                startingIndex = 1;
                lastIndex = 4;
                break;
            case 2:
                startingIndex = 5;
                lastIndex = 9;
                break;
            default:

                break;
        }

        songNum = getMaxValFromArray();
        while (songNum > 0)
        {
            sounds[songNum].Play();
            songNum = getMaxValFromArray();
        }
        flag = 0;
       
            StartCoroutine(WaitForSeconds(seconds));
    }
    
    private void Awake()
    {
        if (instance != null)
            Debug.LogError("More than one AudioManager in the scene");
        instance = this;

    }

    private void Start()
    {
        flag = 0;
        timePressed = new int[sounds.Length];
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
            timePressed[i] = 0;
        }
        time = null;
        GameObject _goo = new GameObject("Treshold");
        _goo.transform.SetParent(this.transform);
        Scene objpravi = SceneManager.GetActiveScene();
        Scene level1 = SceneManager.GetSceneByName("Level 1");
        Scene level2 = SceneManager.GetSceneByName("Level 2");


        int currLevel = 0;
        if (objpravi.Equals(level2))
            currLevel = 2;
        if (objpravi.Equals(level1))
            currLevel = 1;


        int startingIndex = 0;
        int lastIndex = 0;

        float seconds=0f;

        switch (currLevel)
        {
            case 1:
                seconds = 11f;
                break;
            case 2:
                seconds = 21f;
                break;
            default:

                break;
        }
       StartCoroutine( WaitForSeconds(seconds));
        for(int i=2;i<50;i++)
        {
            StartCoroutine(WaitForSeconds(i*seconds));
        }

    }

    private void identifySongs()
    {
        Scene objpravi = SceneManager.GetActiveScene();
        Scene level1 = SceneManager.GetSceneByName("Level 1");
        Scene level2 = SceneManager.GetSceneByName("Level 2");
        if (Input.GetKeyDown("1"))
        {
            if (objpravi.Equals(level1))
            {
                //      sounds[1].SetSource(new AudioSource());
                timePressed[1]++;


            }
            else if (objpravi.Equals(level2))
            {
                //     sounds[5].SetSource(new AudioSource());
                timePressed[5]++;

            }
        }
        else if (Input.GetKeyDown("2"))
        {
            if (objpravi.Equals(level1))
            {

                //    sounds[2].SetSource(new AudioSource());
                timePressed[2]++;
            }
            else if (objpravi.Equals(level2))
            {

                //   sounds[6].SetSource(new AudioSource());
                timePressed[6]++;
            }

        }
        else if (Input.GetKeyDown("3"))
        {
            if (objpravi.Equals(level1))
            {

                //   sounds[3].SetSource(new AudioSource());
                timePressed[3]++;
            }
            else if (objpravi.Equals(level2))
            {

                //  sounds[7].SetSource(new AudioSource());
                timePressed[7]++;
            }
        }
        else if (Input.GetKeyDown("4"))
        {
            if (objpravi.Equals(level1))
            {
                // sounds[4].SetSource(new AudioSource());
                timePressed[4]++;

            }
            else if (objpravi.Equals(level2))
            {
                // sounds[8].SetSource(new AudioSource());
                timePressed[8]++;

            }
        }
        else if (Input.GetKeyDown("5"))
        {
            if (objpravi.Equals(level2))
            {
                // sounds[9].SetSource(new AudioSource());
                timePressed[9]++;

            }
        }

        int currLevel = 0;
        if (objpravi.Equals(level2))
            currLevel = 2;
        if (objpravi.Equals(level1))
            currLevel = 1;
        int songNum;
        for (int i=24; i<73;i++)
        {
            if (Input.GetKeyDown(i + ""))
            {
                switch (currLevel)
                {
                    case 1:
                        songNum = i % 4 + 1;
                        break;
                    case 2:
                        songNum = i % 5 + 1 + 4;
                        break;
                    default:
                        songNum = 1;
                        break;
                }
                timePressed[songNum]++;
            }
                     

        }
        


        
    }

    private void addToPlayQueue(int level)
    {

    }

    private void Update()
    {
        Scene objpravi = SceneManager.GetActiveScene();
        Scene level1 = SceneManager.GetSceneByName("Level 1");
        Scene level2 = SceneManager.GetSceneByName("Level 2");
        if (time==null)
        {
            if (objpravi.Equals(level1))
            {
                sounds[1].Play();
            }
            else if (objpravi.Equals(level2))
            {  
                sounds[5].Play();
            }
        }
        identifySongs();
       

    }

    public void PlaySound(string _name)
    {
        for(int i =0; i< sounds.Length; i++)
        {
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("AudioManager: Sound not found" + _name);

    }
}
