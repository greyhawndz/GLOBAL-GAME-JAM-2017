using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
    public float speed;
    public int waitTimeMin;
    public int waitTimeMax;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private int waitTime;
    private float targetX;
    private float targetY;
    private Vector2 targetPos;

    public GameObject bulletSpawner;

    // Use this for initialization
    void Start()
    {
        waitTime = Random.Range(waitTimeMin, waitTimeMax);
        targetPos = new Vector2(0, 0.5f);
        Invoke("NextMove", 1.846f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void NextMove()
    {
        waitTime = Random.Range(waitTimeMin, waitTimeMax);
        targetX = Random.Range(xMin, xMax);
        targetY = Random.Range(yMin, yMax);
        targetPos = new Vector2(targetX, targetY);
        Invoke("NextMove", 1.846f);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetPos, speed * Time.deltaTime);
    }
}
