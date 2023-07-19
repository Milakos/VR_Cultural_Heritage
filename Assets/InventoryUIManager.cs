using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public Button[] buttons;
    public TMP_Text[] texts;
    public Image[] images;


    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>(false);
        images = GetComponentsInChildren<Image>();
        texts = GetComponentsInChildren<TMP_Text>();
    }

    public bool IsOccupied() 
    {
        return true;
    }

    public void ChangeInventoryButtonImage(Sprite item, string text, SO SOitem)
    {
        images[0].sprite = item;
        texts[0].text = text;
        buttons[0].GetComponent<ButtonManager>().item = SOitem;
    }
    public void ClearInventoryButtonImage()
    {
        images[0].sprite = null;
        texts[0].text = null;
    }

}
