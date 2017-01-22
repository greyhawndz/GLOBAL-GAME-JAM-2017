using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    float lastTime;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        Debug.Log("Time Elapsed: " + Mathf.Floor(Time.realtimeSinceStartup));
        lastTime = Time.realtimeSinceStartup;
        

        
    }
}
