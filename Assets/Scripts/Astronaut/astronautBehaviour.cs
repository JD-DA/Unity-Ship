using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astronautBehaviour : MonoBehaviour
{
    private Vector3 rightTopCameraBorder;
    private Vector3 leftBottomCameraBorder;
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x< leftBottomCameraBorder.x - (gameObject.GetComponent<SpriteRenderer> ().bounds.size.x/2)){
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.name=="shoot_Orange(Clone)"){
            Destroy(collider.gameObject);
        }
        Destroy(gameObject);
    }
}
