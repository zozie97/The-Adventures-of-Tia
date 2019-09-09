using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollected : MonoBehaviour
{
    public static int items;
    public int ItemCollected;
    Text text;

    void Start(){
    	text = GetComponent<Text>();
    	items = 0;
        ItemCollected = items;
    }

    void Update(){
    	if(items < 0){
    		items = 0;
    	}
    	text.text = "" + items;
    }

    public static void AddItems(int itemsToAdd){
    	items += itemsToAdd;
    }
    public static void Reset(){
    	items = 0;
    }
}
