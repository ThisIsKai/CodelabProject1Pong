using using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	public AudioSource effect_player; //the audiosource component
	public AudioClip[] effect_sources;//the clips that will go in it
	public static SoundManager Instance;// this script


	void Awake() {
		if (Instance) //if soundmanager
		DestroyImmediate(gameObject);	// don't make a new one if there is already one
		else { DontDestroyOnLoad(transform.gameObject);	// but if not, then we want one
		Instance = this;
		}//end dontdestroyonload
	}//END AWAKE
		
	void Start () {
	}//END START

	void Update () {
	}//END UPDATE
	public void PlaySoundEffect (string effectName){	// This will play a sound effect with the filename passed to it if it's in effect_sources
		foreach (AudioClip clip in effect_sources) { //
			if (clip.name == effectName) { //if the clip name is the effect name
				effect_player.clip = clip; //the clip
				effect_player.loop = false; //then don't loop it
				effect_player.Play(); //then play it
			}//end if clip
		}//end foreach
	}//END PLAY SOUND EFFECT
}//END SCRIPT