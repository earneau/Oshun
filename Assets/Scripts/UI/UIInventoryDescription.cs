using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDescription : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text title;

    [SerializeField]
    private TMP_Text description;


    public void Awake()         // when we start, reset all the descriptions
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        itemImage.gameObject.SetActive(false);      // no image
        title.text = "";                            // no title
        description.text = "";                      // no text
    }

    public void SetDescription(Sprite sprite, string itemName,
        string itemDescription)
    {
        itemImage.gameObject.SetActive(true);       // show the white background
        itemImage.sprite = sprite;                  // show the sprite of the object
        title.text = itemName;
        description.text = itemDescription;
    }
}
