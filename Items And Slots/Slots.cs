using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Items item;

    public Image icon;

    public Sprite defaultIcon;

    public int slotIndex;

    public int amount;

    public TMP_Text textAmount;

    public bool isMax;

    private void Update()
    {
        if(item == null)
        {
            amount = 0;
            textAmount.text = amount.ToString();
            icon.sprite = defaultIcon;
        }
        else
        {
            textAmount.text = amount.ToString();
            icon.sprite = item.icon;
        }
    }
}
