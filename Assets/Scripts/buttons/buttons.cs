using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    
    GameObject pauseMenu;
    GameObject pauseButton;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("pauseMenu");
        pauseButton = GameObject.FindGameObjectWithTag("pauseButton");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        GameObject.Find("battleMusic").GetComponent<AudioSource>().Pause();
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void playGame()
    {
        Time.timeScale = 1;
        GameObject.Find("battleMusic").GetComponent<AudioSource>().Play();
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        
    }
    
    //shows objects with ShowOnPause tag
    public void showPaused(){
        pauseMenu.SetActive(true);
    }

    //hides objects with ShowOnPause tag
    public void hidePaused(){
        pauseMenu.SetActive(false);
    }
}
