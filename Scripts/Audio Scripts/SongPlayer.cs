using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour {
    AudioSource audioSource;

    [SerializeField] Song song;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        PlaySong();
    }

    private void Update() {
        if (audioSource.time > song.LoopSeconds()) {
            audioSource.time = audioSource.time - song.LoopSeconds() + song.IntroSeconds();
        }
    }

    public void PlaySong() {
        audioSource.clip = song.Clip();
        audioSource.Play();
    }
}
