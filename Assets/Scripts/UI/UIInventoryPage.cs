using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField]
        private UIInventoryItem itemPrefab;     // referencing all items tied thanks to the prefab

        [SerializeField]
        private RectTransform contentPanel;

        List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();      // used to store our items in the inventory

        public void Initialize(int inventorysize)       // initializes the inventory of size inventorysize
        {
            for (int i = 0; i < inventorysize; i++)
            {
                UIInventoryItem item =            
                    Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                item.transform.SetParent(contentPanel);
                listOfUIItems.Add(item);  // storing current item in the list
                item.OnItemClicked += HandleItemSelection;
                item.OnItemBeginDrag += HandleBeginDrag;
                item.OnItemDroppedOn += HandleSwap;
                item.OnItemEndDrag += HandleEndDrag;
                item.OnRightMouseBtnClick += HandleShowItemActions;
            }
        }

        private void HandleShowItemActions(UIInventoryItem obj)
        {

        }

        private void HandleEndDrag(UIInventoryItem obj)
        {
            
        }

        private void HandleSwap(UIInventoryItem obj)
        {
            
        }

        private void HandleBeginDrag(UIInventoryItem obj)
        {
            
        }

        private void HandleItemSelection(UIInventoryItem obj)
        {
            Debug.Log(obj.name);
        }

        public void Show()
        {
            gameObject.SetActive(true);     // if the object is in the inventory, show it
        }

        public void Hide()
        {
            gameObject.SetActive(false);    // if not, hide it
        }
    }
}