using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public int slotsAmount;

    public GameObject _inventoryContent;

    public Slots slot;

    public void Start()
    {
        CreateSlots();
    }

    //This method creates slots based on the slots amount
    public void CreateSlots()
    {
        for(int i = 0; i < slotsAmount; i++)
        {
            Slots newSlot = Instantiate(slot, _inventoryContent.transform);
            FindObjectOfType<InventoryManager>().slots.Add(newSlot);
            newSlot.slotIndex = FindObjectOfType<InventoryManager>().slots.Count;
        }
    }
}
