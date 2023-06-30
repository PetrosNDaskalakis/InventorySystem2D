using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InventoryManager manager;

    public List<Items> items = new();

    public int gold;

    private void Start()
    {
        manager = FindObjectOfType<InventoryManager>();
    }

    public void BuyHealthPotion()
    {
        manager.StoreItem(items[0],1);
    }

    public void BuyManaPotion()
    {
        manager.StoreItem(items[1], 1);
    }

    public void BuyPowerPotion()
    {
        manager.StoreItem(items[2], 1);
    }
}
