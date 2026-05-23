using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float normalSpeed = 5f;
    [SerializeField] float destroyPickupTimer;

    [SerializeField] TMP_Text boostText;

    bool boostActive;

    void Start()
    {
        boostText.gameObject.SetActive(false);
        boostActive = false;
    }

    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1;
        }

        float moveAmount = currentSpeed * move * Time.deltaTime;
        float steerAmount = steerSpeed * steer * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost") && !boostActive)
        {
            Destroy(collision.gameObject, destroyPickupTimer);
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            boostActive = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        currentSpeed = normalSpeed;
        boostText.gameObject.SetActive(false);
        boostActive = false;
    }
}
