using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject currCheckpoint;
    private SpriteMovement sprite;
    public HealthBar healthBar;
    public Animator animation;
    public GameObject respawnParticle;
    public GameObject deathParticle;
    public float delay;
    public GameObject playerSprite;


    void Start()
    {
        sprite = FindObjectOfType<SpriteMovement>();
        healthBar = FindObjectOfType<HealthBar>();  

        animation.SetBool("Portal_null", false);
        animation.SetBool("Portal_start", true); 
    }

    void update(){
        animation.SetBool("Portal_null", true);
        animation.SetBool("Portal_start", false);
    }

    public void Respawn(){
        StartCoroutine("RespawnCo");
        Instantiate(playerSprite);
    }

    public void RespawnFall(){
        sprite.transform.position = currCheckpoint.transform.position;
        healthBar.isDead = false;

        Instantiate(respawnParticle, currCheckpoint.transform.position, currCheckpoint.transform.rotation);

        animation.SetBool("Portal_start", true);
        animation.SetBool("Portal_null", false);
    }

    public IEnumerator RespawnCo(){
        Instantiate(deathParticle, playerSprite.transform.position, playerSprite.transform.rotation);
        // Destroy(playerSprite);
        playerSprite.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(delay);

        sprite.transform.position = currCheckpoint.transform.position;
        // Instantiate(playerSprite);
        playerSprite.GetComponent<Renderer>().enabled = true;
        healthBar.resetHealth();
        healthBar.isDead = false;

        Instantiate(respawnParticle, currCheckpoint.transform.position, currCheckpoint.transform.rotation);
        animation.SetBool("Portal_start", true);
        animation.SetBool("Portal_null", false);
    }

}
