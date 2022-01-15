using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    private Vector2 targetPosition;

    private Vector3 currentPosition;

    private Vector3 velocity;
    private Vector3 rightBottomCameraBorder;
    private Vector3 leftTopCameraBorder;

    private Vector3 top;
    private Vector3 bottom;
    private bool goTop;

    private Camera cam;
    private Vector3 siz;

    private int score;
    private int life;

    [NonSerialized] public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        score = 100;
        cam = Camera.main;
        currentPosition = transform.position;
        top = cam.ViewportToWorldPoint(new Vector3(0.85f, 1, currentPosition.z));
        bottom = cam.ViewportToWorldPoint(new Vector3(0.85f, 0, currentPosition.z));
        rightBottomCameraBorder = cam.ViewportToWorldPoint(new Vector3(1, 0, 0));
        leftTopCameraBorder = cam.ViewportToWorldPoint(new Vector3(0, 1, 0));
        targetPosition = top;
        goTop = true;
        siz = gameObject.GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentPosition = transform.position;
            if (currentPosition.y > leftTopCameraBorder.y - (siz.y / 2.1))
            {
                targetPosition = bottom;
            }
            else if (currentPosition.y < rightBottomCameraBorder.y + (siz.y / 2.1))
            {
                targetPosition = top;
            }

            transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity,
                1f, Math.Abs(timelineHandler.Instance.speed.x) / 2);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Vector3 tmpPos = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z);
        if (collider.name == "shoot_Orange(Clone)")
        {
            invulnerable comp =  gameObject.GetComponent<invulnerable>();
            if (comp.inactive)
            {
                var  game = Instantiate(Resources.Load("explosion"), tmpPos, Quaternion.identity) as GameObject;
                gameState.Instance.addScorePlayer(score);
                --life;
                soundState.Instance.shipTouched();
                if (life == 0)
                {
                    timelineHandler.Instance.ennemyDestroyed();
                    dataSavings.Instance.saveWickedShipDestroyed();
                    dropBonus();
                    Destroy(gameObject);
                }
                comp.startFlash();
            }

        }
        else
        {
            var game = Instantiate(Resources.Load("explosion"), tmpPos, Quaternion.identity) as GameObject;
            Destroy(collider.gameObject);
        }
    }

    private void dropBonus()
    {
        var prefab = "";
        if (!gameState.Instance.doubleShoot)
        {
            prefab = "power-up_0";
        }
        else
        {
            prefab = "power-up_1";
        }
        GameObject pgo =
            GameObject.Instantiate(Resources.Load(prefab), gameObject.transform.position, Quaternion.identity) as GameObject;
                    
        pgo.GetComponent<Rigidbody2D> ().velocity = timelineHandler.Instance.speed;
    }
}
