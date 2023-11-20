using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;        // item sprite
    
    [SerializeField]
    private TMP_Text quantityTxt;       // quantity of particular item in the inventory

    [SerializeField]
    private Image borderImage;      // necessary to toggle on/off border image whenever item is selected

    // creates an action event whenever item is clicked, dropped, dragged, or when the right click is used
    public event Action<UIInventoryItem> OnItemClicked,
        OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
        OnRightMouseBtnClick;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }
    public void ResetData()
    {
        itemImage.gameObject.SetActive(false);
        empty = true;
    }
    public void Deselect()
    {
        borderImage.enabled = false;        // border image doesnt appear when item isnt selected
    }

    public void Select()
    {
        borderImage.enabled = true; 
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);      // exists in the inventory
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";      // converts int to a string
        empty = false;
    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
