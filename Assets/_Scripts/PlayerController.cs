using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    float width;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        width = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	void Update ()
    {
        Vector2 vel = Vector2.zero;
		if (InputManager.right)
        {
            vel += speed * Vector2.right;
        }
        if (InputManager.left)
        {
            vel += speed * Vector2.left;
        }
        rb.velocity = vel;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Ball"))
        {
            float dist = Mathf.Abs(other.transform.position.x - (transform.position.x - width / 2f));
            float variance = dist / width;
            other.GetComponent<Ball>().Bounce(variance);
        }
    }
}
