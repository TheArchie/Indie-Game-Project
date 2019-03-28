using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour {

    public Item item;
    private Image sprite;



    private void Awake()
    {
        sprite = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            sprite.color = Color.white;
            sprite.sprite = item.itemIcon;
        }
        else
        {
            sprite.color = Color.clear;
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
