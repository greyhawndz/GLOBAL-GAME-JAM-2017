using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Rand
{
    public float min = 0;
    public float max = 0;

    public float rand()
    {
        return Random.Range(min, max);
    }
}

[System.Serializable]
public class Path
{
    public Vector3 pos;
}

[System.Serializable]
public enum PathType { Linear, Bezier, Catmull };

public class Pattern : MonoBehaviour
{
    public GameObject bullet;
    public int count;
    public float offset;
    public float speed;
    public float accel;
    public float delayBetweenShots;
    public int duration = -1;

    public Rand speedRand;
    public Rand accelRand;
    public Rand targetRand;

    public GameObject target;

    private float halfOffset;
    private float offsetInterval;
    private int counter;
    private float delayBetweenShotsCounter;

    public bool targetPlayer;

    public bool relativeTo;
    public Vector2 targetLocation;

    public GameObject onDeath;

    // Use this for initialization
    void Start()
    {
        halfOffset = offset * ((count - 1) / 2);
        offsetInterval = 0;

        for (int i = 0; i < count; i++)
        {
            Invoke("createBullet", (delayBetweenShots * (i + 1)));
        }
    }

    void createBullet()
    {
        GameObject newBullet = (GameObject)Instantiate(bullet, GetComponent<Transform>().position, new Quaternion());
        newBullet.transform.SetParent(this.transform);
        newBullet.GetComponent<Bullet>().origin = this.transform;
        if (target)
        {
            newBullet.GetComponent<Bullet>().target = target.transform;
        } else
        {
            newBullet.GetComponent<Bullet>().target = null;
        }
        newBullet.GetComponent<Bullet>().speed = speed + speedRand.rand();
        newBullet.GetComponent<Bullet>().accel = accel + accelRand.rand();
        newBullet.GetComponent<Bullet>().offset = (offsetInterval - halfOffset) + targetRand.rand();
        newBullet.GetComponent<Bullet>().duration = duration;
        newBullet.GetComponent<Bullet>().onDeath = onDeath;
        offsetInterval += offset;
    }

    // Update is called once per frame
    void Update()
    {
    }   
}
