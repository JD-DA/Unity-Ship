using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astronautGeneration : MonoBehaviour
{
    private Vector3 rightTopCameraBorder;
    private Vector3 leftBottomCameraBorder;
    private Vector3 siz;
    private int chance = 10000;

    public bool creating = true;
    // Start is called before the first frame update
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        if(creating)
        {
            if (Random.Range(1, chance) == 42 )
                {
                    var mov = new Vector3(rightTopCameraBorder.x + (rightTopCameraBorder.x / 2),
                        Random.Range(leftBottomCameraBorder.y, rightTopCameraBorder.y), 0);
                    
                    GameObject pgo =
                        GameObject.Instantiate(Resources.Load("astronaut"), mov, Quaternion.identity) as GameObject;
                    
                    pgo.GetComponent<Rigidbody2D> ().velocity = gameState.Instance.speed;
                    pgo.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);
                }
            
        }
    }
}
