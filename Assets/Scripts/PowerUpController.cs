using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public static PowerUpType collectedPU;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.tag == "SolidPU")
            {
                collectedPU = PowerUpType.Solid;
            }
            if (this.tag == "LiquidPU")
            {
                collectedPU = PowerUpType.Liquid;
            }
            if (this.tag == "GasPU")
            {
                collectedPU = PowerUpType.Gas;
            }
            PlayerController.hasPowerUp = true;
            AudioManager.instance.PlaySound("GetPowerUp");

            //ParticleSystem _insParticles = Instantiate(particles, this.transform.position, Quaternion.identity);

            //Destroy(_insParticles, 2);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
