using UnityEngine;
using System.Collections;

public class LinearMovement : MonoBehaviour {

    public GameObject start;
    public GameObject end;
    private Vector2 startVector;
    private Vector2 endVector;
    private Vector2 current;
    public float speed;
    public float duration;

    public bool randomized;
    public float randomizationFrequency;
    public Rand randx;
    public Rand randy;
    public bool active;

    // Use this for initialization
    void Start()
    {
        startVector = start.transform.position;
        endVector = end.transform.position;
        current = startVector;
        Invoke("die", duration);
        Invoke("randmize", randomizationFrequency);
    }

    void randmize()
    {
        if(active)
        {
            startVector = new Vector2(randx.rand(), randy.rand());
            endVector = new Vector2(randx.rand(), randy.rand());
            current = startVector;
            this.transform.position = startVector;
            Invoke("randmize", randomizationFrequency);
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            current = Vector2.MoveTowards(current, endVector, speed * Time.deltaTime);
            this.transform.position = current;
        }
    }
}
