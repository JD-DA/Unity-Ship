using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparkling : MonoBehaviour
{
    private Vector3 rightTopCameraBorder;
    private Vector3 leftTopCameraBorder;
    private Vector3 rightBottomCameraBorder;
    private Vector3 leftBottomCameraBorder;
    private Vector3 siz;

    public bool sparkleStill = false;
    // Start is called before the first frame update
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,0));
        rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,0,0));
        leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,1,0));
        rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        var avgFrameRate = (int) (Time.frameCount / Time.time);
        if(Random.Range(1,avgFrameRate*timelineHandler.Instance.sparkling)==4 && Time.timeScale==1){
            var mov = new Vector3 (Random.Range(leftTopCameraBorder.x,rightTopCameraBorder.x),Random.Range(leftBottomCameraBorder.y,rightTopCameraBorder.y),0);
            GameObject gY	=	Instantiate(Resources.Load("sparkle"), mov	,Quaternion.identity) as	GameObject;
            if(sparkleStill)
                Destroy(gY.GetComponent<moveSparkle>());
        }
    }

    
}
