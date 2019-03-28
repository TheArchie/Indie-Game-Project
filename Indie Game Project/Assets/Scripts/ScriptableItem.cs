using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ScriptableItem : ScriptableObject {

    public string itemName = "New Item";
    public Sprite itemIcon = null;
    public bool isDefaultItem = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
