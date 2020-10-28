using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float impulseForce;
    private float initialImpulseForce,halfImpulseForce, doubleImpulseForce;
    
    private Vector2 direction;
    private Vector2 heading;
    private float distance;
    private Vector2 mousePos;
    private Vector2 playerPos;

    public ParticleSystem particles;
    public ParticleSystem enemiesParticles;

    public static PowerUpType powType;
    public static bool powerUpActive, hasPowerUp;
    public float powerUpTimer = 5;
    private float initialPowerUpTimer = 5;

    public GameObject solidSprite, liquidSprite, gasSprite;
    
    private SpriteRenderer spriteRenderer;

    private int jumpCounter;

    public Animator animator;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powType = PowerUpType.None;
        initialImpulseForce = impulseForce;
        halfImpulseForce = impulseForce / 2;
        doubleImpulseForce = impulseForce * 2;
        initialPowerUpTimer = powerUpTimer;
        powType = PowerUpType.None;
        hasPowerUp = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        powerUpActive = false;

        AudioManager.instance.PlaySound("Music");



    }

    void Update()
    {
        if (rb !=null && !PauseManager.pauseOn &&!WinCondition.winCondition)
        {

            
            if (powerUpActive)
            {
                powerUpTimer-=Time.deltaTime;
                Debug.Log(powerUpTimer);
                if (powerUpTimer <= 0)
                {
                    powerUpTimer = initialPowerUpTimer;
                    powerUpActive = false;
                    powType = PowerUpType.None;
                }
            }
            CheckPowerUp(powType);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerPos = rb.transform.position;
            ButtonsInput();
        }
        if (jumpCounter > 2)
            jumpCounter = 2;

        animator.SetFloat("RightVelocity", rb.velocity.x);
        animator.SetFloat("UpVelocity", rb.velocity.y);

    }

    private void FixedUpdate()
    {

    }

    private void ButtonsInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (jumpCounter > 0)
            {
                rb.velocity = Vector2.zero;
                heading = mousePos - playerPos;
                AudioManager.instance.PlaySound("Jump");
                rb.AddForce(heading.normalized * impulseForce, ForceMode2D.Impulse);
                jumpCounter--;
            }
           
        }
    }

    public void CheckPowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.Solid:
                this.gameObject.tag = "Solid";
                solidSprite.SetActive(true);
                //Asingación de color segun power up
                break;
            case PowerUpType.Liquid:
                //Asingación de color segun power up
                impulseForce = doubleImpulseForce;
                liquidSprite.SetActive(true);

                break;
            case PowerUpType.Gas:
                rb.gravityScale = 0;
                //Asingación de color segun power up
                gasSprite.SetActive(true);

                break;
            case PowerUpType.None:
                //Asingación de color segun power up
                impulseForce = initialImpulseForce;
                rb.gravityScale = 1;
                this.gameObject.tag = "Player";

                if(gasSprite.activeInHierarchy)
                    gasSprite.SetActive(false);

                if(solidSprite.activeInHierarchy)
                    solidSprite.SetActive(false);

                if(liquidSprite.activeInHierarchy)
                    liquidSprite.SetActive(false);


                break;
            default:

                break;
        }
    }

    public static bool ActivePowerUp(PowerUpType powerUpType)
    {
        if (hasPowerUp)
        {
            powType = powerUpType;
            hasPowerUp = false;
            return powerUpActive = true;
        }
        else
        {
            return false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            jumpCounter = 2;
        }

        //if (collision.gameObject.CompareTag("Coin"))
        //{
        //    BinaryPersistanceManager.totalCoins++;
        //    collision.gameObject.SetActive(false);
        //    Destroy(collision.gameObject);
        //}
        if (this.gameObject.tag == "Player")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                ParticleSystem _insParticles = Instantiate(particles, this.transform.position, Quaternion.identity);
                AudioManager.instance.PlaySound("Destroyed");

                Destroy(_insParticles, 2);
                this.gameObject.SetActive(false);
                Destroy(rb);
            }

            if (collision.gameObject.CompareTag("Projectile"))
            {
                ParticleSystem _insParticles = Instantiate(particles, this.transform.position, Quaternion.identity);
                AudioManager.instance.PlaySound("Destroyed");

                Destroy(_insParticles, 2);

                this.gameObject.SetActive(false);
                Destroy(rb);

                collision.gameObject.SetActive(false);
                Destroy(collision.rigidbody);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                ParticleSystem _insParticles = Instantiate(enemiesParticles, collision.transform.position, Quaternion.identity);
                Destroy(_insParticles, 2);
                AudioManager.instance.PlaySound("Destroyed");

                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.CompareTag("Projectile"))
            {
                ParticleSystem _insParticles = Instantiate(enemiesParticles, collision.transform.position, Quaternion.identity);
                Destroy(_insParticles, 2);
                AudioManager.instance.PlaySound("Destroyed");

                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            jumpCounter = 2;
        }

        if (collision.gameObject.layer == 9)
        {
            jumpCounter = 1;
            impulseForce = halfImpulseForce;
        }
        else
        {
            impulseForce = initialImpulseForce;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ParticleSystem _insParticles = Instantiate(particles, this.transform.position, Quaternion.identity);

            Destroy(_insParticles, 2);
            this.gameObject.SetActive(false);
            Destroy(rb);
        }
    }
}
public enum PowerUpType
{
    Solid,
    Liquid,
    Gas,
    None
}
