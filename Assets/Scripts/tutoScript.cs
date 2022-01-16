using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutoScript : MonoBehaviour
{
    private GameObject touchTuto;

    private GameObject keyTuto;

    private GameObject music;

    private GameObject sounds;
    // Start is called before the first frame update
    void Start()
    {
        touchTuto = GameObject.FindGameObjectWithTag("asteroid");
        keyTuto = GameObject.FindGameObjectWithTag("ship");
        touchTuto.SetActive(false);
        music = GameObject.Find("musicTitle");
        sounds = GameObject.FindGameObjectWithTag("sounds");
    }

    public void switchToKey()
    {
        soundState.Instance.buttonTouchedd();
        Debug.Log("switchToKey");
        touchTuto.SetActive(false);
        keyTuto.SetActive(true);
    }
    
    public void switchToTouch()
    {
        soundState.Instance.buttonTouchedd();
        touchTuto.SetActive(true);
        keyTuto.SetActive(false);
    }

    public void gotoMenu()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("titlescreen");
    }

    public void play()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("InfinitePlay");
        Destroy(music);
        Destroy(sounds);
    }
}
