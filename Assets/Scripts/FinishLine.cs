using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadSceneDelaySeconds = 1f;
    [SerializeField] private ParticleSystem finishLineEffect;
    private SurfaceEffector2D surfaceEffector2D;

    private void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           finishLineEffect.Play();
           GetComponent<AudioSource>().Play();
           surfaceEffector2D.forceScale = 0f;
           Invoke(nameof(ReloadScene), reloadSceneDelaySeconds);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
