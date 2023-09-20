using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] private float reloadSceneDelaySeconds = 0.5f;
    [SerializeField] private ParticleSystem playerCrashEffect;
    [SerializeField] private AudioClip crashSfx;

    private bool hasCrashed = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !hasCrashed)
        {
            hasCrashed = true;
            playerCrashEffect.Play();
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
            Invoke(nameof(ReloadScene), reloadSceneDelaySeconds);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
