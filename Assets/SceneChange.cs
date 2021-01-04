using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Scene
{
    Title,
    GamePlay,
    Result,
}

public class SceneChange : MonoBehaviour
{
    public Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scene == Scene.Title)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("GamePlay");
            }
        }
        else
        {
            if(scene == Scene.GamePlay)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Result");
                }
            }
            else
            {
                if (scene == Scene.Result)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        SceneManager.LoadScene("Title");
                    }
                }

            }
        }
        
    }
}
