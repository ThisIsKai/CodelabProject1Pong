using using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	public AudioSource effect_player; //the audiosource component
	public AudioClip[] effect_sources;//the clips that will go in it
	public static SoundManager Instance;


	void Awake() {
		if (Instance)
		DestroyImmediate(gameObject);						// If there's already a music manager, don't create a new one.
		else { DontDestroyOnLoad(transform.gameObject);			// Otherwise, keep this instance persistent through every scene.
		Instance = this;
		}
	}


	void Start () {
	}//END START

	void Update () {
	}//END UPDATE
	public void PlaySoundEffect (string effectName){	// This will play a sound effect with the filename passed to it if it's in effect_sources
		foreach (AudioClip clip in effect_sources) {
			if (clip.name == effectName) {
				effect_player.clip = clip;
				effect_player.loop = true;
				effect_player.Play();
			}
		}
	}
}