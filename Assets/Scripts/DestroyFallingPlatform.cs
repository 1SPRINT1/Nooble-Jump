using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        } 
    }
}
