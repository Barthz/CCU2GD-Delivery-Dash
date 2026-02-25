using UnityEngine;

public class Delivery : MonoBehaviour
{
    const string PACKAGE_TAG = "Package";
    const string CUSTOMER_TAG = "Customer";

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if the tag is package, then do something
        if (collision.CompareTag(PACKAGE_TAG))
        {
            Debug.Log("Package " + collision.gameObject.name + " collected!");
        }

        if (collision.CompareTag(CUSTOMER_TAG))
        {
            Debug.Log("Package delivered to " + collision.gameObject.name + "!");
        }
    }
}
