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
	[SerializeField] private float health = 1000f;
	[SerializeField] private LevelManager lvl;
	[SerializeField] private Animator anim;
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
		Invoke("NextMove", 3.696f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
		if (health <= 1000) {
			Debug.Log ("Boss Weak");
			anim.SetBool ("isDamaged", true);

		}

    }

    void NextMove()
    {
        waitTime = Random.Range(waitTimeMin, waitTimeMax);
        targetX = Random.Range(xMin, xMax);
        targetY = Random.Range(yMin, yMax);
        targetPos = new Vector2(targetX, targetY);
        Invoke("NextMove", 3.696f);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetPos, speed * Time.deltaTime);
    }

	public void OnTriggerEnter2D(Collider2D collider)
	{	
		if (collider.gameObject.tag == "Friendly Bullet") {
			PlayerBullet bullet = collider.gameObject.GetComponent<PlayerBullet> ();
			health -= bullet.getDamage ();
			bullet.hit ();
			if (health <= 0) {
				lvl.loadLevel ("Menu");
			}
		}
	}
}
