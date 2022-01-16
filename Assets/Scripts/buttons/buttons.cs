using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    
    GameObject pauseMenu;
    GameObject pauseButton;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("pauseMenu");
        pauseButton = GameObject.FindGameObjectWithTag("pauseButton");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame()
    {
        soundState.Instance.buttonTouchedd();
        Time.timeScale = 0;
        GameObject.Find("battleMusic").GetComponent<AudioSource>().Pause();
        showPaused();
    }
    public void playGame()
    {
        soundState.Instance.buttonTouchedd();
        Time.timeScale = 1;
        GameObject.Find("battleMusic").GetComponent<AudioSource>().Play();
        hidePaused();

    }
    
    //shows objects with ShowOnPause tag
    public void showPaused(){
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    //hides objects with ShowOnPause tag
    public void hidePaused(){
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void goToMenu()
    {
        soundState.Instance.buttonTouchedd();
        Time.timeScale = 1;
        /*gameState.Instance.autodestruction();
        Destroy(gameState.Instance);
        Destroy(Camera.main);*/
        SceneManager.LoadScene("titlescreen");
    }
    
    public void resetGame()
    {
        soundState.Instance.buttonTouchedd();
        Time.timeScale = 1;
        gameState.Instance.resteScore();
        SceneManager.LoadScene("InfinitePlay");
        
    }
}
