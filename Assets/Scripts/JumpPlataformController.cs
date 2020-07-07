using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlataformController : MonoBehaviour
{
    public float impulseForce = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, impulseForce), ForceMode2D.Impulse);
        }
    }
}
