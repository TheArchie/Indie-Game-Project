using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> playerItems = new List<Item>();

    public ItemDatabase itemDatabase;
    public UIInventory uiInventory;

	// Use this for initialization
	void Start ()
    {
        AddItem(0);
        //RemoveItem(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        playerItems.Add(itemToAdd);
        uiInventory.AddNewItem(itemToAdd);
        Debug.Log("Added Item" + itemToAdd.itemTitle);
    }

    public Item ItemCheck(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = ItemCheck(id);
        if(itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
            uiInventory.RemoveItem(itemToRemove);
            Debug.Log("Removed Item " + itemToRemove.itemTitle);
        }
    }
}
