using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Lists")]
    [Space]
    public List<Items> inventory = new List<Items>();
    public List<Slots> slots = new List<Slots>();

    [Header("Inventory Status")]
    [Space]
    public int maxCapacity;
    public bool isMax = false;
    public bool hasItem;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Capacity();
    }

    // This method Stores The Item Into Slots
    public void StoreItem(Items item, int amount)
    {
        if (isMax == true)
        {
            Debug.Log("Cant store item because inventory is full");
            return;
        }
        else
        {
            if (inventory.Contains(item))
            {
                hasItem = true;
            }

            if (hasItem == false)
            {
                Debug.Log("New item");

                foreach (Slots slot in slots)
                {
                    if (slot.item == null)
                    {
                        inventory.Add(item);

                        //Check the inventory capacity
                        ReachedMaxCapacity();

                        //Setup slot
                        slot.item = item;
                        slot.amount += amount;
                        item.slot = slot;
                        break;
                    }
                }
            }

            if (hasItem == true)
            {
                AddAmount(item, amount);
            }
        }
    }

    //This Method Adds The Amount Of An Item In The Slots
    public void AddAmount(Items item, int amount)
    {
        inventory.Add(item);

        //Check the inventory capacity
        ReachedMaxCapacity();

        foreach (Slots slot in slots)
        {
            if (slot.item == item)
            {
                Debug.Log("Slot has Item: " + item);

                if (slot.isMax)
                {
                    continue; //This will continue the foreach loop
                }

                if (!slot.isMax)
                {
                    Debug.Log("Slot: " + slot + " isn't max");

                    if (slot.amount == item.limit)
                    {
                        slot.isMax = true;
                        Debug.Log("slot is max");

                        foreach (Slots s in slots)
                        {
                            if (s.item == null)
                            {
                                Debug.Log("Items Stored in new slot");

                                //Setup slot
                                s.item = item;
                                s.amount += amount;
                                item.slot = s;
                                return;
                            }
                        }
                    }
                    else
                    {
                        slot.amount += amount;
                        Debug.Log("Added item amount to slot");
                        return;
                    }
                }
            }
        }
    }

    public void Capacity()
    {
        //The max capacity of the inventory is the amount of slots multiplied by the slot's limit
        maxCapacity = slots.Count * 5;
    }

    public void ReachedMaxCapacity()
    {
        //This checks the inventory if its at max capacity
        if(inventory.Count == maxCapacity)
        {
            isMax = true;
        }
    }
}