using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    private float width;
    public float shootSpeed = 5;
    public float laserDuration = 2;
    public float chargeTime = 5;
    private int state;

    private int STATE_SHOOT = 0;
    private int STATE_CHARGE = 1;

    // Use this for initialization
    void Start () {
		state = STATE_SHOOT;
        Invoke("shoot", 0);
    }

    void shoot()
    {
        Debug.Log("shootinggggg");
        state = STATE_SHOOT;
        width = 0;
        Invoke("charge", laserDuration);
        this.transform.localScale = new Vector3(0, 3.0f, 1.0f);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    void charge()
    {
        state = STATE_CHARGE;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.transform.localScale = new Vector3(0.0f, 3.0f, 1.0f);
        Invoke("shoot", chargeTime);
    }
	
	// Update is called once per frame
	void Update () {
        if( state == STATE_SHOOT )
        {
            width = Mathf.MoveTowards(width, 1.0f, shootSpeed * Time.deltaTime);
            this.transform.localScale = new Vector3(width, 3.0f, 1.0f);
            this.GetComponent<BoxCollider2D>().transform.localScale = new Vector3(width, 3.0f, 1.0f);
        }
	}
}
