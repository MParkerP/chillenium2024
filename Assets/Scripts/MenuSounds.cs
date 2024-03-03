using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource AS;
    public AudioClip mainMusic;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.clip = mainMusic;
        AS.Play();
    }
    public void PlayClick()
    {
        AS.PlayOneShot(clickSound);
    }
}
