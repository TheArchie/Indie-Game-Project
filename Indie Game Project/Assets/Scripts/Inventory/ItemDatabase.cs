using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
       return items.Find(item=> item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.itemTitle == itemName);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "Diamond Sword", "A Diamond Sword",
            new Dictionary<string, int>{
                { "Power", 15 },
                { "Defence", 10 }
            })
         };
    }
}
