using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralProperties : MonoBehaviour
{
    // Screen properties
    Vector2 bounds;

    public static GeneralProperties propertiesInstance;

    private bool gameWon;

    // Start is called before the first frame update
    void Awake()
    {
        if (propertiesInstance != null)
        {
            Destroy(propertiesInstance);
        }
        else
        {
            propertiesInstance = this;
        }

        DontDestroyOnLoad(this);

        // initalize screen boundaries
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        gameWon = false;
    }

    public Vector2 GetScreenBoundary()
    {
        return bounds;
    }

    public void SetResults(bool didWin, SceneChange s)
    {
        gameWon = didWin;
        s.LoadGameOver();
        
    }

    public bool GetResults()
    {
        return gameWon;
    }
}
