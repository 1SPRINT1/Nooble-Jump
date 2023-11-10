using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    public float jumpForce;
    public AudioSource AU;

    private void Start()
    {
        AU = GetComponent<AudioSource>();
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        NubJump.Instace.NoobleRG.velocity = Vector2.up * jumpForce; 
        AU.Play();
    }
}
