using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundAtDeath : MonoBehaviour {
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        AudioClip audioClipDeath = Resources.Load<AudioClip>("Sounds/Player/Explosion");
        audioSource.PlayOneShot(audioClipDeath);

    }

}
