using UnityEngine;
using System.Collections;

public class LaserController : PatternEventController {

    public GameObject spawn;
    public GameObject laser;

	// Use this for initialization
	void Start ()
    {
        Invoke("startLaser", start);
	}

    void startLaser()
    {
        GameObject newLaser = (GameObject) Instantiate(laser, spawn.transform.position, spawn.transform.rotation);
        newLaser.transform.SetParent(spawn.transform);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
