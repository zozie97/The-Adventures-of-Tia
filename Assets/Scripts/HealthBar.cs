using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public static int health;
	public int maxHealth;
    public Slider healthSlider;

	private LevelManager levelManager;

    public bool isDead;

    void Start(){

        healthSlider = GetComponent<Slider>();
    	health = maxHealth;

    	levelManager = FindObjectOfType<LevelManager>();

        isDead = false;
    }

    void Update(){

        if(health <= 0 && !isDead){
        	levelManager.Respawn();
            isDead = true;
        }

        if(health > maxHealth){
            health = maxHealth;
        }

        healthSlider.value = health;
    }

    public static void injured(int damage){
    	health -= damage;
    }

    public void resetHealth(){
    	health = maxHealth;
    }
}
