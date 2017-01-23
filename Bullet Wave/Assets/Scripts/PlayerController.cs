using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {

	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private int health = 3;
	[SerializeField] private float padding = 1f;
	[SerializeField] private int bombs = 3;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float bulletSpeed = 3f;
	[SerializeField] private float fireRate = 5f;
	[SerializeField] private float launchBombTime = 3f;
	[SerializeField] private GameObject bombPrefab;
	[SerializeField] private AudioClip shotFX;
	[SerializeField] private AudioClip hitFX;
	[SerializeField] private AudioClip deathFX;
	[SerializeField] private Animator anim;
	[SerializeField] private LevelManager lvl;
	[SerializeField] private Text text;
	private GameObject bombObject;
	private GameObject bulletObject;
	private GameObject[] enemyBullets;

	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;
	private AudioSource src;
	private bool isDead = false;
	private Rigidbody2D playerBody;
	// Use this for initialization
	void Start () {
		src = this.GetComponent<AudioSource> ();
		playerBody = this.GetComponent<Rigidbody2D>();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		Vector3 upperMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		//Vector3 bottomMost = Camera. main.ViewPortToWorldPoint(new Vector3(0,1,distance));
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
		yMin = leftMost.y + padding;
		yMax = upperMost.y - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				InvokeRepeating ("shoot", 0f, fireRate);
			}
			if (Input.GetKeyUp (KeyCode.Z)) {
				CancelInvoke ();
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				Invoke ("throwBomb", launchBombTime);
			}
			if (Input.GetKeyUp (KeyCode.X)) {
				CancelInvoke ();
			}
			moveShip ();
			slowDown ();
		} 
		else {
			CancelInvoke ();
			if (Input.GetKeyDown (KeyCode.R)) {
				lvl.loadLevel ("Menu");
			}
		}
	}

	private void shoot(){
		Debug.Log ("pew pew pew");
		bulletObject = (GameObject)Instantiate (bulletPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.4f, bulletPrefab.transform.position.z), Quaternion.identity);
		Rigidbody2D bulletBody = bulletObject.GetComponent<Rigidbody2D>();
		bulletBody.velocity = new Vector3 (0, bulletSpeed, bulletObject.transform.position.z);
		src.clip = shotFX;
		src.volume = 0.8f;
		src.Play ();
	}

	private void moveShip(){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} 
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		} 
		else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		}

		//clamp
		float newX = Mathf.Clamp(transform.position.x, xMin,xMax);
		float newY = Mathf.Clamp (transform.position.y, yMin, yMax);
		transform.position = new Vector3 (newX, newY, transform.position.z);

	}

	private void slowDown(){
		if (Input.GetKey (KeyCode.LeftShift)) {
			moveSpeed = 2.75f;
		} else {
			moveSpeed = 5;
		}
	}

	public void OnTriggerEnter2D(Collider2D collider){
		string tag = collider.gameObject.tag;
		if (tag == "EnemyBullet") {
			Debug.Log ("Ouch");
			health -= 1;
			Debug.Log ("Health left: " + health);
			src.clip = hitFX;
			src.volume = 0.8f;
			src.Play ();

			GameObject[] list = GameObject.FindGameObjectsWithTag ("EnemyBullet");
			for (int i = 0; i < list.Length; i++) {
				Destroy (list [i].gameObject);
			}

			if (health <= 0) {
				src.clip = deathFX;
				src.volume = 0.8f;
				src.Play ();
				die ();
			}
		}
	}

	private void die(){
		Debug.Log ("RIP");
		isDead = true;
		anim.SetBool ("isDead", true);
		if (text != null) {
			text.gameObject.SetActive (true);
		}
		
	}

	private void throwBomb(){
		if (bombs > 0) {
			bombObject = (GameObject)Instantiate (bombPrefab, new Vector3 (this.transform.position.x, this.transform.position.y, bombPrefab.transform.position.z), Quaternion.identity);
			bombs -= 1;
			Debug.Log ("Bomb Count: " + bombs);
			MusicPlayer.getMusicPlayer ().muteMusic ();
			MusicPlayer.getMusicPlayer ().Invoke ("unMuteMusic", 2);
		}
		else {
			Debug.Log ("You are out of bombs");
		}
	}

	public int getBombCount(){
		return bombs;
	}

	public int getPlayerHealth(){
		return health;
	}

}
