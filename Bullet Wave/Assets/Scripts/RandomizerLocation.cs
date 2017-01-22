using UnityEngine;
using System.Collections;

public class RandomizerLocation : MonoBehaviour {

    public Rand x;
    public Rand y;
    public float frequency;
    public bool active;

	// Use this for initialization
	void Start ()
    {
        Invoke("move", frequency);
    }
   
    void die()
    {
        Destroy(this.gameObject);
    }

    void move()
    {
        if(active)
        {
            float newX = x.rand();
            float newY = y.rand();
            Invoke("move", frequency);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
