using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int currentGems;
    [SerializeField] private Text gemsText;
    private bool haveAllGems;
    public bool greenPlayerInDoors = false;
    public bool redPlayerInDoors = false;
    public GameObject PausePanel;
    public bool isGamePaused;
    public Animator sceneTransition;
    void Start()
    {
        currentGems = 0;
        haveAllGems = false;
        PausePanel.SetActive(false);
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == true)
            {
                UnPauseGame();
            }
            else if (isGamePaused == false)
            {
                PauseGame();
            }
        }

      if((greenPlayerInDoors && redPlayerInDoors) && currentGems == 4){
            //loading next lv
            LoadNextLevel();
      }
      
    }

    void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        //animation
        sceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }

    public void AddGem(){
        currentGems = currentGems + 1;
        gemsText.text = currentGems.ToString();
        if(currentGems == 4) haveAllGems = true;
    }
    //pause panel buttons
    public void PauseGame(){
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        isGamePaused = true;
        Cursor.visible = true;
    }


    public void UnPauseGame(){
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        isGamePaused = false;
        Cursor.visible = false;
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UnPauseGame();
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
