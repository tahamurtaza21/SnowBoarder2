using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float LevelLostDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && hasCrashed == false)
        {
            hasCrashed = true;
            FindObjectOfType<Player>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", LevelLostDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

