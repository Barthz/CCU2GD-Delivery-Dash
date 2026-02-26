using UnityEngine;

public class Delivery : MonoBehaviour
{
    const string PACKAGE_TAG = "Package";
    const string CUSTOMER_TAG = "Customer";

    private bool hasPackage;
    [SerializeField] private float destroyDelay = 0.3f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if the tag is package, then do something
        if (collision.CompareTag(PACKAGE_TAG) && !hasPackage)
        {
            Debug.Log("Package " + collision.gameObject.name + " collected!");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag(CUSTOMER_TAG) && hasPackage)
        {
            Debug.Log("Package delivered to " + collision.gameObject.name + "!");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, destroyDelay);
        }
    }
}
