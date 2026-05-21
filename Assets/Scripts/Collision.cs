using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Owwwie ;(");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Im Triggered!");
    }
}
