using UnityEngine;
using System.Collections;

public class LinePattern : MonoBehaviour {

    public Vector2 start;
    public Vector2 end;
    public float interval;
    public float speed;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update () {
        start = Vector2.MoveTowards(start, end, speed * Time.deltaTime);
        if(Vector2.Distance(start, end) <= 1)
        {

        }
    }
}
