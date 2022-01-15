using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsBehaviourTitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject music;
    void Start()
    {
        music = GameObject.Find("musicTitle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void playInfiniteGame()
    {
        soundState.Instance.buttonTouchedd();
        if (PlayerPrefs.GetInt("tutoShowed", 0) == 0)
        {
            PlayerPrefs.SetInt("tutoShowed",1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("tutoScreen");
        }
        else
        {
            SceneManager.LoadScene("InfinitePlay");
            Destroy(music);
        }
        
        
        
    }

    public void goToStat()
    {
        SceneManager.LoadScene("statScreen");
    }
    
    public void goToSettings()
    {
        SceneManager.LoadScene("settingsScreen");
    }
}
