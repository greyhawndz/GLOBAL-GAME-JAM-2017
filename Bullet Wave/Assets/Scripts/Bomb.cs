using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	[SerializeField] private float xMax = 5f;
	[SerializeField] private float yMax = 5f;
	[SerializeField] private float growthRate = 1f;

	// Update is called once per frame
	void Update () {
		grow ();
	}

	void grow(){
		if (transform.localScale.x < xMax && transform.localScale.y < yMax) {
			transform.localScale += new Vector3 (growthRate, growthRate, this.transform.position.z);
			transform.Rotate (Vector3.forward * -60);
			CircleCollider2D col = (CircleCollider2D)this.GetComponent<CircleCollider2D> ();
			col.radius += growthRate;
		} 
		else 
		{
			Destroy (gameObject);
		}


	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "EnemyBullet") {
			Debug.Log ("Collided bomb");
			Destroy (collider.gameObject);
		}
	}
		
}
