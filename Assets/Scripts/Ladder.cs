using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
	SpriteMovement sprite;

    void Start()
    {
        sprite = FindObjectOfType<SpriteMovement>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Sprite"){
            sprite.ladder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.name == "Sprite"){
            sprite.ladder = false;
        }
    }
}
