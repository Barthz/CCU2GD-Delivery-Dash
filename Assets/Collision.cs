using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Detected with: " + collision.gameObject.name);
    }
}
