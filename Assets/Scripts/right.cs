using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class right : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ButtonControllerright bc2;

    public void OnPointerDown(PointerEventData eventData)
    {
        bc2.right = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bc2.right = false;
    }

}
