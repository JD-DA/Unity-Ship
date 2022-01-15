using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class shoot : MonoBehaviour
{
    private Vector3 siz;

    private timelineHandler handler;

    [NonSerialized]
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        siz = gameObject.GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            handler = timelineHandler.Instance;
            var avgFrameRate = (int) (Time.frameCount / Time.time);
            if (Random.Range(1, (int) (avgFrameRate * 3)) == 2)
            {
                Vector3 tmpPos = new Vector3(transform.position.x - siz.x,
                    transform.position.y,
                    transform.position.z);
                GameObject gY = Instantiate(Resources.Load("fireShoot"), tmpPos, Quaternion.identity) as GameObject;
                gY.GetComponent<moveShoot>().setShoot(-10);
                soundState.Instance.touchButtonSound();
            }
        }
    }
}
