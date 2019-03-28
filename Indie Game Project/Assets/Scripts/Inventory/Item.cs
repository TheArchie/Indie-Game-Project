using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public string itemTitle;
    public string itemDescription;
    public int id;
    public Sprite itemIcon;

    public Dictionary<string, int> itemStats = new Dictionary<string, int>();


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Item(int id, string itemTitle, string itemDescription, Dictionary<string, int> itemStats)
    {
        this.id = id;
        this.itemTitle = itemTitle;
        this.itemDescription = itemDescription;
        this.itemIcon = Resources.Load<Sprite>("Assets/Sprites" + itemTitle);
        this.itemStats = itemStats;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.itemTitle = item.itemTitle;
        this.itemDescription = item.itemDescription;
        this.itemIcon = Resources.Load<Sprite>("Assets/Sprites" + item.itemTitle);
        this.itemStats = item.itemStats;
    }
}
