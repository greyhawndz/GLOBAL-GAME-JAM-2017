using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	[SerializeField] private float damage = 10f;

	public void setDamage(float n){
		damage = n;
	}

	public float getDamage(){
		return damage;
	}

	public void hit(){
		Destroy (gameObject);
	}
}
