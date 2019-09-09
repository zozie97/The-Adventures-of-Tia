using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEndAnimation : MonoBehaviour
{
	public Animator animation;

    void OnTriggerEnter2D(Collider2D other){
    	animation.SetBool("Portal_open", false);
    	// animation.SetBool("Portal_spin", false);
        animation.SetBool("Portal_null", true);

        if(ItemsCollected.items == 5){ 
            animation.SetBool("Portal_open", true);
            // animation.SetBool("Portal_spin", true);
            animation.SetBool("Portal_null", false);
        }
    }

}
