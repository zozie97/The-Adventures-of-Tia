using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSprite : MonoBehaviour
{

	public int damage;
	public GameObject damageParticle;
    public GameObject sprite;
    public float delay;

    // public float wait(){
    //     yield return new WaitForSeconds(delay);
    // }
    
    void OnTriggerEnter2D(Collider2D other){
    	if(other.name == "Sprite"){
    		HealthBar.injured(damage);
    		// particle effects
            // wait();
    		Instantiate(damageParticle, sprite.transform.position, sprite.transform.rotation);
    		
    	}
    }
}
