using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public GameObject falling;
    public GameObject Platf;
    public BoxCollider2D box2D;
    public AudioSource AUD;

    private void Start()
    {
        box2D.GetComponent<BoxCollider2D>();
        AUD.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.y < 0)
        {
            NubJump.Instace.NoobleRG.velocity = Vector2.up * 20f;
            Destroy(gameObject, 3f);
            falling.SetActive(true);
            Platf.SetActive(false);
            box2D.isTrigger = true;
            AUD.Play();
        }
        
    }
}
