using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlyBtCtrl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler 
{
    private Transform tr;
    public Transform StartTr;  // 처음 시작하는 위치 ( FlyButton위치 )           
    public Transform endTr;       // 부스트의 위치
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isMouseDown = false;
    private float fStraightAngle;
    
    private PlayerCtrl player;
    // public static 
    void Start()
    {
        tr = GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();



        // StartPosition = tr.InverseTransformPoint(tr.position); //StartTr.InverseTransformPoint(StartTr.position);

        //endPosition = endTr.InverseTransformPoint(endTr.position);

        //fStraightAngle = (StartPosition.y - endPosition.y) / (StartPosition.x - endPosition.x); // 직선의방정식 기울기 
    }

 
   void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isMouseDown = true;

        startPosition = tr.position;
        endPosition = endTr.position;

        fStraightAngle = (endPosition.y - startPosition.y) / (endPosition.x - startPosition.x); // 직선의방정식 기울기 

        player.FlyBtDown();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    { 
        if (EventSystem.current.IsPointerOverGameObject())
        {
            tr.position = CalculatePositionBetweenStartPositionAndBoostPosition(Input.mousePosition.x);//Input.mousePosition;////
            if (tr.position == endPosition)
            {
                player.FlyBtUp();
                player.boostdown();
            }
            else
            {
                player.boostup();
                player.FlyBtDown();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown = false;
        tr.position = startPosition;

        player.FlyBtUp();
        player.boostup();
    }

    private Vector3 CalculatePositionBetweenStartPositionAndBoostPosition(float _fX) // 마우스의 x값을 넣어서 y값을 정해주는 함수 
    {
       
        
        if (_fX < startPosition.x) _fX = startPosition.x;
        if (_fX > endPosition.x) _fX = endPosition.x;

       
        float _fY = fStraightAngle * (_fX - startPosition.x) + startPosition.y;
        return new Vector3(_fX,_fY, 0f);
    }

}
