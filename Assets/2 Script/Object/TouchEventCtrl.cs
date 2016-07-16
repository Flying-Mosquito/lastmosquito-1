using UnityEngine;
using System.Collections;

public class TouchEventCtrl : MonoBehaviour {

    delegate void listener(string _str, float _fX, float _fY);
    event listener begin, move, end;
	// Use this for initialization
	void Start ()
    {
        begin += OnTouch;
        move += OnTouch;
        end += OnTouch;
	}
	
	// Update is called once per frame
	void Update ()
    {

        int iTouchCount = Input.touchCount;
        if (0 == iTouchCount)
            return;

        for( int i = 0; i < iTouchCount; ++i)
        {
            Touch   touch = Input.GetTouch(i);
            int     iId = touch.fingerId;       // 현재 인덱스는 사용하지 않는다

            Vector2 touchPosition = touch.position; // 터치 좌표

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    {
                        begin("OnTouchBegin", touchPosition.x, touchPosition.y);
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        move("OnTouchMove", touchPosition.x, touchPosition.y);
                        break;
                    } 
                case TouchPhase.Ended:
                    {
                        end("OnTouchEnd", touchPosition.x, touchPosition.y);
                        break;
                    }
            }



        }
	}

    void OnTouch(string _str, float _fX, float _fY)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(_fX, _fY));
        RaycastHit hit;
        GameObject hitObject;
        switch (_str)
        {
            case "OnTouchBegin":
                {
                    if(hitObject = CollisionManager.Instance.Get_MouseCollisionObj(3000f, "UI"))
                    {
                        hitObject.SendMessage("OnTouchBegin");
                    }
                    break;
                }
            case "OnTouchMove":
                {
                    if (hitObject = CollisionManager.Instance.Get_MouseCollisionObj(3000f, "UI"))
                    {
                        hitObject.SendMessage("OnTouchMove");
                    }

                    break;
                }
            case "OnTouchEnd":
                {
                    if (hitObject = CollisionManager.Instance.Get_MouseCollisionObj(3000f, "UI"))
                    {
                        hitObject.SendMessage("OnTouchEnd");
                    }
                    break;
                }
        }
    }
}
