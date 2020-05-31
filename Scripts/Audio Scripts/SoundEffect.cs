using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] float volume;
    [SerializeField] AudioClip[] soundEffects;

    public void PlaySoundEffect() {
        int random = Random.Range(0, soundEffects.Length);

        AudioSource.PlayClipAtPoint(soundEffects[random], Camera.main.transform.position, volume);
    }


}
