using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDustTrailEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerDustTrailEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerDustTrailEffect.Stop();
        }

    }
}
