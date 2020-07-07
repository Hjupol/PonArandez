using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    public float speed = 10;
    public void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb != null)
        {
            rb.AddForce(direction * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            Destroy(rb);
        }

        if (collision.gameObject.CompareTag("Untagged"))
        {
            this.gameObject.SetActive(false);
            Destroy(this);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            
        }

    }
}
