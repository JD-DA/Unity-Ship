using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreation : MonoBehaviour
{
    private Vector3 rightTopCameraBorder;
    private Vector3 leftBottomCameraBorder;
    private Vector3 siz;

    private timelineHandler handler;

    // Start is called before the first frame update
    void Start()
    {
        handler = timelineHandler.Instance;
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        handler = timelineHandler.Instance;
        if(handler.createEnemy)
        {
            var avgFrameRate = (int) (Time.frameCount / Time.time);
            if (Random.Range(1, (int)handler.ennemy*avgFrameRate) == 42 ) 
            {
                var mov = new Vector3(rightTopCameraBorder.x + (rightTopCameraBorder.x / 2),
                    Random.Range(leftBottomCameraBorder.y, rightTopCameraBorder.y), 0);
                    
                GameObject pgo =
                    GameObject.Instantiate(Resources.Load("WickedShipS/badShip"), mov,Quaternion.Euler(0, 0, 180)) as GameObject;

                handler.createEnemy = false;
            }
            
        }
    }
}
