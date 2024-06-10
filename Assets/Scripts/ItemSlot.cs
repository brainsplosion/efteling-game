using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    //public int ok = 0;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<DraggableItem>().parentAfterDrag = transform;
        }
    }

    public void Update()
    {
        /*if ((transform.childCount != 0) && (ok ==  0))
        {
            Debug.Log("child detected");
            WeaponSizing.Instance.Biggerer();
            ok = 1;
        }
        if ((transform.childCount == 0) && (ok == 1))
        {
            Debug.Log("child removed");
            WeaponSizing.Instance.Smallerer();
            ok = 0;
        }*/

    }
    /*
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
    */
}
