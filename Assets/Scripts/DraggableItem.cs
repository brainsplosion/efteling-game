using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Image image;
    CanvasGroup group;
    public Transform parentAfterDrag;
    public GameObject swordLenghtDescription;
    public GameObject equipOrUnequip;
    public GameObject capBiggerBranch1;

    public void Start()
    {
        image = GetComponent<Image>();
        group = GetComponent<CanvasGroup>();
        swordLenghtDescription.SetActive(false);
        equipOrUnequip.SetActive(false);
        capBiggerBranch1.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        group.alpha = .5f;
        image.raycastTarget = false;
        swordLenghtDescription.SetActive(true);
        equipOrUnequip.SetActive(true);
        capBiggerBranch1.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);

        group.alpha = 1f;
        image.raycastTarget = true;
        swordLenghtDescription.SetActive(false);
        equipOrUnequip.SetActive(false);
        capBiggerBranch1.SetActive(false);
    }

}