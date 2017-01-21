using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private GameObject bombObject;
	private GameObject bulletObject;
	private GameObject[] enemyBullets;
	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;
	// Use this for initialization
	void Start () {
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

	private void shoot(){
			Debug.Log ("pew pew pew");
			bulletObject = (GameObject)Instantiate (bulletPrefab, new Vector3(this.transform.position.x, this.transform.position.y, bulletPrefab.transform.position.z), Quaternion.identity);
			Rigidbody2D bulletBody = bulletObject.GetComponent<Rigidbody2D>();
		bulletBody.velocity = new Vector3 (0, bulletSpeed, bulletObject.transform.position.z);
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
		Debug.Log ("Ouch");
		Bullet enemyBullet = collider.gameObject.GetComponent<Bullet> ();
		if (enemyBullet) {
			health -= 1;
			Debug.Log ("Health left: " + health);
			if (health <= 0) {
				die ();
			}
		}
	}

	private void die(){
		Debug.Log ("RIP");
		Destroy (gameObject);
	}

	private void throwBomb(){
		
	/*	if (enemyBullets == null) {
			enemyBullets = GameObject.FindGameObjectsWithTag ("EnemyBullet");
			Debug.Log ("Found " + enemyBullets.Length +" enemy bullets");
		} 
		if (bombs > 0) {
			Debug.Log ("Bombs Away");
			bombs -= 1;
			Debug.Log ("Bomb count: " + bombs);

			foreach (GameObject enemyBullet in enemyBullets) {
				Destroy (enemyBullet);
				Debug.Log ("Bullet destroyed");
			}

			MusicPlayer.getMusicPlayer ().muteMusic ();
			MusicPlayer.getMusicPlayer ().Invoke ("unMuteMusic", 2);
		} 
		else {
			Debug.Log ("You are out of bombs");
		}
	*/
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


}
