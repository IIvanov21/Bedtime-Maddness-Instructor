using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip babyLaugh;
    [SerializeField] private float volume = 1.0f;

    private void Start()
    {
        playerAudioSource.ignoreListenerPause = true;
        playerAudioSource.ignoreListenerVolume = true;
    }
    private void Update()
    {
        //if (GameManager.State == GameState.Play)
        {
            //Play the Audio only once
            if (Input.GetKeyDown(KeyCode.E) && !playerAudioSource.isPlaying)//Check to ensure you don't play it multiple times
            {
                playerAudioSource.PlayOneShot(babyLaugh, volume);
            }
        }
    }
}
