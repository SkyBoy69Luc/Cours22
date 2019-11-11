using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleAfterDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
}
