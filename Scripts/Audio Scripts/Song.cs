using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Song")]
public class Song : ScriptableObject {
    [SerializeField] AudioClip song;

    [SerializeField] float introSeconds;
    [SerializeField] float loopSeconds;

    public AudioClip Clip() {
        return song;
    }

    public float IntroSeconds() {
        return introSeconds;
    }

    public float LoopSeconds() {
        return loopSeconds;
    }
}
