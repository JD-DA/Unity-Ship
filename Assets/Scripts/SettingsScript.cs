using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private Toggle musicToggle;

    private Toggle soundToggle;

    // Start is called before the first frame update
    void Start()
    {
        musicToggle = .FindGameObjectWithTag("asteroid") ;
        soundToggle = GameObject.FindGameObjectWithTag("ship");
    }
    
    public void gotoMenu()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("titlescreen");
    }
    public void gotoTuto()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("tutoScreen");
    }
    
    public void gotoCredits()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("titlescreen");
    }

    public void reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void music(bool set)
    {
        if (set)
        {
            PlayerPrefs.SetInt("playMusicc",1);
        }else
            PlayerPrefs.SetInt("playMusicc",0);
        PlayerPrefs.Save();
        
    }
    public void sounds(bool set)
    {
        if (set)
        {
            PlayerPrefs.SetInt("playSounds",1);
        }else
            PlayerPrefs.SetInt("playSounds",0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("titlescreen");
        
    }
}
