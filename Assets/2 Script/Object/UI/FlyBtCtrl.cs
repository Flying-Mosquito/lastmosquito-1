using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FlyBtCtrl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler 
{
    public Transform tr;
    public Transform boostTr;
    private Vector3 StartPosition;
    private bool isMouseDown = false;
    
    private PlayerCtrl player;
    // public static 
    void Start()
    {
        tr = GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isMouseDown = true;
        StartPosition = tr.position;
        
        print("눌렀다 " + StartPosition);
        player.FlyBtDown();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            print("드래그한다");
            tr.position = Input.mousePosition;
            player.boostdown();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown = false; 
        tr.position = StartPosition;
        print("뗐다 " + StartPosition);

        player.FlyBtUp();
        player.boostup();
    }
}
