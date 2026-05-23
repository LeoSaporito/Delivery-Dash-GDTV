using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;    
    [SerializeField] float timeToDestroy;
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        { 
            Debug.Log("Picked up package");
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, timeToDestroy);
            hasPackage = true;
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package to customer");
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, timeToDestroy);
            hasPackage = false;
        }
    }
}
