using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    GameController controller;

    void Start()
    {
        controller = FindObjectOfType<GameController>();
        if (controller == null)
            Debug.LogError("No controller was found in the scene");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            controller.Die();
    }
}