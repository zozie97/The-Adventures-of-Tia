using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
	public int itemsToAdd;
	public GameObject damageParticle;
	// public GameObject key;
	// public AudioSource appleSound;
	// public AudioSource keySound;

	public AudioClip sound;
	public float volume;
	AudioSource audio;

	void start(){
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if(other.GetComponent<SpriteMovement>() == null){
			return;
		}

		ItemsCollected.AddItems(itemsToAdd);

		// gameObject.GetComponent<AudioSource>().Play();
		
		// gameObject.GetComponent<AudioSource>().PlayOneShot(sound, volume);
		Destroy(gameObject);

	}
}
