using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    private GameObject musicToggle;

    private GameObject soundToggle;

    // Start is called before the first frame update
    void Start()
    {
        musicToggle = GameObject.FindGameObjectWithTag("asteroid");
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
}
