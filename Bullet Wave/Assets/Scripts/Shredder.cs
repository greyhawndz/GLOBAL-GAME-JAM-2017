using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
	
	[SerializeField] private float height = 5f;
	[SerializeField] private float width = 5f;

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Destroyed bullet");
		Destroy(collider.gameObject);
	}

	void OnDrawGizmos(){
		Gizmos.DrawCube (this.transform.position, new Vector3 (width, height, 0));
	}
}
