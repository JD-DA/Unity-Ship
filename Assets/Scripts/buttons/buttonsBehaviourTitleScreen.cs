using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsBehaviourTitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void playInfiniteGame()
    {
        soundState.Instance.buttonTouchedd();
        SceneManager.LoadScene("InfinitePlay");
        
    }
}
