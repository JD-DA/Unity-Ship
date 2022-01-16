using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidBehaviourTuto : MonoBehaviour
{
     //utilisé dans le tutoriel
    

    void OnTriggerEnter2D(Collider2D collider){
        Vector3 tmpPos = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z);
        if (collider.name == "shoot_Orange(Clone)")
        {
            //Debug.Log(collider.name);
            gameObject.AddComponent<fadeOutFast>();
                GameObject gY = Instantiate(Resources.Load("explosion"), tmpPos, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                Destroy(collider.gameObject);
        }
        
    }
    
    
    
}
