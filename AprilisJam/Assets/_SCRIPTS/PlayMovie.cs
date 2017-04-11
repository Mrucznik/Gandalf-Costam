﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent (typeof(AudioSource))]

public class PlayMovie : MonoBehaviour
{
    public bool loop;
    public bool rickrolled;

    public MovieTexture movie;
    private AudioSource audio;

	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
	    Camera.main.GetComponent<AudioSource>().mute = true;
	    movie.loop = loop;
	    audio.loop = loop;
	}

    void Update()
    {
        if (rickrolled && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(this.gameObject);
        }

        if (!movie.isPlaying)
        {
           Destroy(this.gameObject);
        }
    }
}
