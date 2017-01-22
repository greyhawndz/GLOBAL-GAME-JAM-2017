using UnityEngine;
using System.Collections;

public class RevolvingCircle : MonoBehaviour
{

    public float degrees;
    public float duration;

    // Use this for initialization
    void Start()
    {
        if( duration > 0 )
        {
            Invoke("die", duration);
        }
    }

    void die()
    {
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, degrees);
    }
}
