using UnityEngine;
using System.Collections;

public class RandomStart : MonoBehaviour {

    public Rand startX;
    public Rand startY;

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector2(startX.rand(), startY.rand());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
