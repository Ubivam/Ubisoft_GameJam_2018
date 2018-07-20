using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadLevel()
    {
        int scena = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(scena);
    }
    public void ReturnToLevel()
    {
        int scena = SceneManager.GetActiveScene().buildIndex -1;
        SceneManager.LoadScene(scena);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}
