using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnd : MonoBehaviour
{

	public Animator animation;
    public int beep;
    public GameObject ToDelete;
 
    void OnTriggerEnter2D(Collider2D other){

        if(ItemsCollected.items == 5){ //1 for testing set to 5 for final
            if(other.name == "Sprite"){
                Destroy(ToDelete);
                Debug.Log("GAME IS FINISHED");
            }
        }
    	
    }

}
