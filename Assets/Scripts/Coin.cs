using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Solid"))
        {
            AudioManager.instance.PlaySound("GetCoin");
            BinaryPersistanceManager.totalCoins++;
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //BinaryPersistanceManager.totalCoins++;
            //this.gameObject.SetActive(false);
            //Destroy(this);
        }
    }
}
