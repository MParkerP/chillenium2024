using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public AudioClip explosion;
    public AudioClip thud;
    public AudioClip zap;
    public AudioClip woodBreak;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip effect)
    {
        audioSource.PlayOneShot(effect);
    }


    
}
