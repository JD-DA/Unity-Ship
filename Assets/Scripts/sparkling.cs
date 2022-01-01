using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparkling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1,100)==50||respaws.Length<4){
            var mov = new Vector3 (rightTopCameraBorder.x+(siz.x /2),Random.Range(leftBottomCameraBorder.y,rightTopCameraBorder.y),0);
            GameObject gY	=	Instantiate(Resources.Load("asteroid"), mov	,Quaternion.identity) as	GameObject;
        }
    }
}
