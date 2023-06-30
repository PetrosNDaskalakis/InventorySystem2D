using UnityEngine;

public class Items : MonoBehaviour
{
    //the name of the item.
    public string Name;

    public Sprite icon;

    //the description of the item.
    public string Description;

    public int amount;

    public int limit;

    public bool isStackable = true;

    public Slots slot;

    private void Start()
    {
        if (isStackable)
        {
            limit = 5;
        }
        else
        {
            limit = 1;
        }
    }

    //the ID number that makes it a type example: Potion, Sword, Gun, Armor etc...
    public int iD;

    //the rarity level, from 1 - 5 (common, great, rare, legendary, Godly).
    public int rarityLevel;

    //the power that it gives the player example: +10 hp, +10 mana, +10 attack damage etc...
    public int powerUp;

    //the level to buy is based on the rarity level and the player level
    //if the player's level isnt equal to the level to buy then he cant pick it up or buy it.
    public int levelToBuy;

    //How much is the items worth.
    public int cost;
}
