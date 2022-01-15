using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class introduceShip : MonoBehaviour
{
    private Vector3 targetPosition;

    private Vector3 currentPosition;

    private Vector3 velocity;

    private patrol patpatrouille;

    private shoot shooter;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        Debug.Log($"current position : ${currentPosition}");
        targetPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.86f, 0, 0));
        targetPosition.y = currentPosition.y;
        targetPosition.z = currentPosition.z;
        Debug.Log($"target position : ${targetPosition}");
        patpatrouille = gameObject.GetComponent<patrol>();
        shooter = gameObject.GetComponent<shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        if (gameObject.transform.position.x-0.5f <= targetPosition.x)
        {
            //patrol -> on
            patpatrouille.active = true;
            //shoot -> on
            shooter.active = true;
            Destroy(this);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity,
                0.1f, Math.Abs(timelineHandler.Instance.speed.x));
        }
    }
}
