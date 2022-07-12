using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ButtonQuit(){
        Application.Quit();
    }

    public void ButtonStart(){
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

}
