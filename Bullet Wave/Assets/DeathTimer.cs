using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour {

	public float delay;

	// Use this for initialization
	void Start () {
		Invoke ("die", delay);
	}

	void die() {
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
