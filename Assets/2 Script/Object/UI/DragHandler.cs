using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler 
{
    public Transform tr;
    private Vector3 StartPosition;
    private bool isMouseDown = false;
    // public static 
    void Awake()
    {
        tr = GetComponent<Transform>();    
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isMouseDown = true;
        StartPosition = tr.position;
        
        print("눌렀다 " + StartPosition);
        PlayerCtrl.Instance.FlyBtDown();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        print("드래그한다");
        tr.position = Input.mousePosition;
        PlayerCtrl.Instance.boostdown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMouseDown = false; 
        tr.position = StartPosition;
        print("뗐다 " + StartPosition);
        
        PlayerCtrl.Instance.FlyBtUp();
        PlayerCtrl.Instance.boostup();
    }
}
