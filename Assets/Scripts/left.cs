using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class left : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ButtonControllerleft bc1;

    public void OnPointerDown(PointerEventData eventData)
    {
        bc1.left = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bc1.left = false;
    }

}
