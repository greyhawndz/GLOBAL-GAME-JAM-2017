using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField] private Image hp1;
	[SerializeField] private Image hp2;
	[SerializeField] private Image hp3;
	[SerializeField] private Image bomb1;
	[SerializeField] private Image bomb2;
	[SerializeField] private Image bomb3;
	private PlayerController player;
	// Update is called once per frame
	void Update () {
		player = FindObjectOfType<PlayerController> ();
		if (player != null) {
			
			if (player.getPlayerHealth() == 0 && hp1 != null) {
				Destroy (hp1.gameObject);
			}
			else if (player.getPlayerHealth () == 1 && hp2 != null) {
				Destroy (hp2.gameObject);
			}
			else if (player.getPlayerHealth () == 2 && hp3 != null) {
				Destroy (hp3.gameObject);
			} 

			if (player.getBombCount () == 2 && bomb3 != null) {
				Destroy (bomb3.gameObject);
			} else if (player.getBombCount () == 1 && bomb2 != null) {
				Destroy (bomb2.gameObject);
			} else if (player.getBombCount () == 0 && bomb1 != null) {
				Destroy (bomb1.gameObject);
			}
		} 
	}


}
