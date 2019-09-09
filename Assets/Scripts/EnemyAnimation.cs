using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
	public Animator animation;

    void OnTriggerEnter2D(Collider2D other){
    	if(other.name == "Sprite"){
    		attack();
    	}
    }
    void OnTriggerExit2D(Collider2D other){
    	if(other.name == "Sprite"){
    		noAttack();
    	}
    }

    void attack(){
    	animation.SetBool("Enemy_attack", true);
    	animation.SetBool("Enemy_idle", false);
    }
    void noAttack(){
    	animation.SetBool("Enemy_attack", false);
    	animation.SetBool("Enemy_idle", true);
    }
}
