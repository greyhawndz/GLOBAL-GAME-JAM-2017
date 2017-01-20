using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private int health = 3;
	[SerializeField] private float padding = 1f;
	[SerializeField] private int bombs = 3;
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
		moveShip ();
		slowDown ();
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
		} else if (Input.GetKey (KeyCode.DownArrow)) {
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
}
