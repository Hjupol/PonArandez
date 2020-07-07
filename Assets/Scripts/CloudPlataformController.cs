using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlataformController : MonoBehaviour
{
    private bool touched;
    public float despawnTime = 2;
    private float initialDespawnTime;

    public SpriteRenderer sprite;
    public BoxCollider2D colliderBox;

    // Start is called before the first frame update
    void Start()
    {
        initialDespawnTime = despawnTime;
        colliderBox = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            despawnTime-=Time.deltaTime;
            if (despawnTime < 0)
            {
                sprite.enabled = false;
                colliderBox.enabled = false;
                //this.gameObject.SetActive(false);
                touched = false;
            }
        }
        else
        {
            if (despawnTime < initialDespawnTime)
            {
                despawnTime += Time.deltaTime;
            }
            else
            {
                sprite.enabled = true;
                colliderBox.enabled = true;
                //this.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touched = true;
        }
    }
}
