using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
	public int addHealth;
	public GameObject apple;
	public GameObject healthParticle;

	void OnTriggerEnter2D (Collider2D other){
		
		if(other.GetComponent<SpriteMovement>() == null){
			return;
		}

		HealthBar.injured(-addHealth);
		
		Instantiate(healthParticle, apple.transform.position, apple.transform.rotation);

		Destroy(gameObject);

	}

}


