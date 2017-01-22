using UnityEngine;
using System.Collections;

public class BossProperties : MonoBehaviour {

    public int maxHealth;
    private int health;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}

    public int getHealth()
    {
        return health;
    }

    void die()
    {
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
