using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class down : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ButtonControllerdown bc4;

    public void OnPointerDown(PointerEventData eventData)
    {
        bc4.down = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bc4.down = false;
    }

}