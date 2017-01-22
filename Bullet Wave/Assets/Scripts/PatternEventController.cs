using UnityEngine;
using System.Collections;

[System.Serializable]
public class Timing
{
    public float time;
}

public class PatternEventController : MonoBehaviour
{
    public GameObject target;
    public GameObject origin;
    public GameObject pattern;
    public float duration;
    public float start;
    public float interval;
    public bool repeat;
    public bool useTimings;
    public Timing[] timing;

    // Use this for initialization
    void Start()
    {
        pattern.GetComponent<Pattern>().target = target;

        if (!useTimings)
        {
            Invoke("createPattern", start);
        }
        for(int i = 0; i < timing.Length; i++ )
        {
            Invoke("createPattern", start + timing[i].time);
        }
        Invoke("die", start + duration);
    }

    void createPattern()
    {
        Debug.Log(pattern.name + " Pattern Created at " + origin.transform.position.ToString());
        Instantiate(pattern, origin.transform.position, new Quaternion());
        if (repeat)
        {
            Invoke("createPattern", interval);
        }
    }

    void die()
    {
        Debug.Log("End of Pattern Event");
        repeat = false;
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
