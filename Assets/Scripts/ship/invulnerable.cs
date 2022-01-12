using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invulnerable : MonoBehaviour
{
    private Color originalColour;

    public bool inactive = true;
    // Start is called before the first frame update
    void Start()
    {
        originalColour = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFlash() 
    {
        StartCoroutine("flash");
        inactive = false;
    }
    public IEnumerator flash()
    {
        for (int i = 0; i < 4; i++)
        {
            GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            GetComponent<Renderer>().material.color = originalColour;
            yield return new WaitForSeconds(0.2f);
        }

        inactive = true;
        StopCoroutine("flash");
    }
}
