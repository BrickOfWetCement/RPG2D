using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy_flesh : MonoBehaviour
{
    public float jumpForce = 10f;

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);


        }
    } }

