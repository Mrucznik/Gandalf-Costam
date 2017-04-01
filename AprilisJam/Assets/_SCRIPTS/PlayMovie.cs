using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent (typeof(AudioSource))]

public class PlayMovie : MonoBehaviour
{
    private bool rickrolled = false;
    public MovieTexture movie;
    private AudioSource audio;

	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
	    rickrolled = true;

	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.X) && rickrolled)
            {
                movie.Pause();
                SceneManager.LoadScene(1);
        }
    }
}
