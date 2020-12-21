﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour
{

    public AudioClip sound;
    private Button menuButtons { get { return GetComponent<Button>(); } }
    private static AudioSource soundPlay;

    void Start()
    {
        menuButtons.onClick.AddListener(() => PlaySound());
    }

    void PlaySound()
    {
        if (GetComponent<Image>().color.a > 0.4f)
        {
            soundPlay = Instantiate(gameObject.AddComponent<AudioSource>());
            soundPlay.clip = sound;
            soundPlay.playOnAwake = false;
            soundPlay.PlayOneShot(sound);
            Object.Destroy(soundPlay, 0.5f);
        }
    }
}
