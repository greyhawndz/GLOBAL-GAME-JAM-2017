using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {
    
    private Vector3 startScale;
    private Vector3 endScale;
    private Vector3 scale;
    private float speed;
    private float frequency;
    public bool active;

    // Use this for initialization
    void Start()
    {
        frequency = 0.462f;
        speed = 1;

        startScale = this.transform.localScale;
        scale = startScale;
        endScale = startScale + new Vector3(0.1f, 0.1f, 0.1f);
        Invoke("reset", frequency);
    }

    void reset()
    {
        scale = startScale;
        this.transform.localScale = scale;
        Invoke("reset", frequency);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(active)
        {
            scale = Vector2.MoveTowards(scale, endScale, speed * Time.deltaTime);
            this.transform.localScale = scale;
        }
    }
}
