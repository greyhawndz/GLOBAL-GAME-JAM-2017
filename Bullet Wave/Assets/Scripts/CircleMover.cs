using UnityEngine;
using System.Collections;

public class CircleMover : MonoBehaviour
{
    void Start()
    {
        m_centerPosition = transform.position;
    }

    void Update()
    {
        // Update degrees
        float degreesPerSecond = 360.0f / m_period;
        m_degrees = Mathf.Repeat(m_degrees + (Time.deltaTime * degreesPerSecond), 360.0f);
        float radians = m_degrees * Mathf.Deg2Rad;

        // Offset on circle
        Vector3 offset = new Vector3(m_radius * Mathf.Cos(radians), m_radius * Mathf.Sin(radians), 0.0f);
        transform.position = m_centerPosition + offset;
    }

    Vector3 m_centerPosition;
    float m_degrees;

    [SerializeField]
    float m_radius = 1.0f;

    [SerializeField]
    float m_period = 1.0f;
}