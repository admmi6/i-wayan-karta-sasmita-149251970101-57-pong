using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PongGame");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenAuthor()
    {
        Debug.Log("created by Me");
    }
}
