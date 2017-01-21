using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private int damage = 10;

	public void setDamage(int n){
		damage = n;
	}

	public int getDamage(){
		return damage;
	}

	public void hit(){
		Destroy (gameObject);
	}
}
