using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string name){
		Debug.Log ("Request load for level " + name);
		Cursor.visible = true;

		SceneManager.LoadScene (name);
	}

	public void quitLevel(){
		Debug.Log ("Quitting Level");
		Application.Quit ();
	}

	public void loadNextLevel(){
		//UnityEngine.SceneManagement.SceneManager.LoadScene ();
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene (currentScene.buildIndex + 1);
	}
}
