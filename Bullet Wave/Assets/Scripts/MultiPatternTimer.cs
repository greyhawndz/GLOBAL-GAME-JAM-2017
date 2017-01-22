using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShootTiming
{
    public float time;
    public int location;
    public GameObject pattern;
}
public class MultiPatternTimer : MonoBehaviour {

    public float spawnStart;
    public ShootTiming[] shootTiming;
    public GameObject[] spawn;

	// Use this for initialization
	void Start () {
	    for( int i = 0; i < shootTiming.Length; i++ )
        {
            GameObject spawnPlace = spawn[shootTiming[i].location - 1];
            GameObject pattern = shootTiming[i].pattern;
            float time = shootTiming[i].time + spawnStart;
            StartCoroutine(createPattern(spawnPlace, pattern, time));
        }
    }

    IEnumerator createPattern(GameObject origin, GameObject pattern, float delayTime)
    {
        yield return new WaitForSeconds(delayTime); 

        Instantiate(pattern, origin.transform.position, new Quaternion());
    }

    // Update is called once per frame
    void Update () {
	
	}
}
