using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

    public Transform origin;
    public Transform target;
    public float speed;
    public float offset;
    public float life;
    public float delay = 0;
    public float duration = -1;
    public float accel;
    public GameObject onDeath;
    public IEnumerable<Vector3> pathing;
    public PathType pathingType;
    private float currentSpeed;
    private float netAngle;

    private float moveX;
    private float moveY;
    private bool move;

    // Use this for initialization
    void Start ()
    {
        moveX = 0;
        moveY = speed;
        move = false;
        netAngle = 0;
        float targetX = origin.transform.position.x + 0;
        float targetY = -1;

        if (target != null)
        {
            targetX = target.position.x;
            targetY = target.position.y;
        }
           
        float targetAngle = Mathf.Atan2(targetY - this.transform.position.y, targetX - this.transform.position.x);
        netAngle = targetAngle + (Mathf.Deg2Rad * (offset));
        this.moveX = speed * Mathf.Cos(netAngle);
        this.moveY = speed * Mathf.Sin(netAngle);

        Invoke("startMoving", delay);
    }

    void startMoving()
    {
        move = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(move)
        {
            if(accel != 0)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, speed, accel * Time.deltaTime);
            }else
            {
                currentSpeed = speed;
            }
            this.moveX = currentSpeed * Mathf.Cos(netAngle);
            this.moveY = currentSpeed * Mathf.Sin(netAngle);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
        }
        if (onDeath != null)
        {
            Instantiate(onDeath, this.transform.position, this.transform.rotation);
        }
	}
}
