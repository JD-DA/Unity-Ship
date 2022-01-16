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

    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        soundToggle = GameObject.FindGameObjectWithTag("ship").GetComponent<Toggle>();
        var soundPlaying = PlayerPrefs.GetInt("playSounds", 1);
        Debug.Log($"Start sound : ${soundPlaying}");

        if (soundPlaying == 1)
        {
            soundToggle.isOn = true;
            soundState.Instance.setMakeSounds(true);
        }
        else
        {
            soundToggle.isOn = false;
            soundState.Instance.setMakeSounds(false);
        }

        active = true;
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
        SceneManager.LoadScene("creditScreen");
    }

    public void reset()
    {
        soundState.Instance.buttonTouchedd();
        PlayerPrefs.DeleteAll();
        Destroy(Camera.main.GetComponent<soundState>());
        PlayerPrefs.Save();
        SceneManager.LoadScene("SettingsScreen");
    }

    
    public void sounds(bool set)
    {
        if(active)
        {
            if (set)
            {
                PlayerPrefs.SetInt("playSounds", 1);
            }
            else
                PlayerPrefs.SetInt("playSounds", 0);
            Debug.Log($"sounds : ${set}");
            PlayerPrefs.Save();
            soundState.Instance.setMakeSounds(set);
            SceneManager.LoadScene("SettingsScreen");
            
        }
    }
}
