using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Info"))
        {
            Invoke("LoadGame", 10f);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void LoadInfo()
    {
        SceneManager.LoadScene("Info");
    }


}
