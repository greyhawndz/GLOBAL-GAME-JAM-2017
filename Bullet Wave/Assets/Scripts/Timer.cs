using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public GameObject spawn;
    public GameObject laser;
    public float delay;

	// Use this for initialization
	void Start ()
    {
        Invoke("startLaser", delay);
	}

    void startLaser()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
