using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    float width;

	void Start ()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	void Update ()
    {
		if (InputManager.right)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.right);
        }
        if (InputManager.left)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.left);
        }
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
