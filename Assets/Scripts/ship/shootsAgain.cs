using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shootsAgain : MonoBehaviour
{
	private Vector3 siz;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;
    // Start is called before the first frame update
    void Start()
    {
	    leftBottomCameraBorder = Camera.main.ViewportToScreenPoint(new Vector3 (0,0,0));
	    rightTopCameraBorder = Camera.main.ViewportToScreenPoint(new Vector3 (1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        siz.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
		bool sp = Input.GetKeyDown(KeyCode.Space);
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				//Debug.Log($"TouchEvent ! {touch.position.x} , {touch.position.y} ");
				//Debug.Log($"IsoverUI : {IsPointerOverUI(i)}");
				//Debug.Log($"touch posi > righTopcamera : {touch.position.x > rightTopCameraBorder.x / 2}");
				if (touch.phase == TouchPhase.Began && !(IsPointerOverUI(i)) &&
				    touch.position.x > rightTopCameraBorder.x / 2)
				{
					
					//Debug.Log($"position camera ! rtop {rightTopCameraBorder.x} , {rightTopCameraBorder.y} ");
					//Debug.Log($"position camera ! lBottom {leftBottomCameraBorder.x} , {leftBottomCameraBorder.y} ");
					sp = true;
				}
			}
		}
		if(sp){
			Vector3 tmpPos = new Vector3(transform.position.x + siz.x,
			transform.position.y,
			transform.position.z);
			GameObject gY = Instantiate (Resources.Load("shoot_Orange"),tmpPos,Quaternion.identity) as GameObject;
			gY.GetComponent<moveShoot>().setShoot(10);
			soundState.Instance.touchButtonSound();
		}
    }
    
    public bool IsPointerOverUI(int fingerId)
    {
	    EventSystem eventSystem = EventSystem.current;
	    return (eventSystem.IsPointerOverGameObject(fingerId)
	            && eventSystem.currentSelectedGameObject != null);
    }
}
