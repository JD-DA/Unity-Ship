using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsBehaviourTitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject music;
    private GameObject sounds;
    void Start()
    {
        music = GameObject.Find("musicTitle");
        sounds = GameObject.FindGameObjectWithTag("sounds");
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
            Destroy(sounds);
        }
        
        
        
    }

    public void goToStat()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("statScreen");
    }
    
    public void goToSettings()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("settingsScreen");
    }
}
