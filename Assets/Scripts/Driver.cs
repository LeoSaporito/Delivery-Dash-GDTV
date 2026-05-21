using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float steerSpeed = 0.5f;

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

        float moveAmount = moveSpeed * move * Time.deltaTime;
        float steerAmount = steerSpeed * steer * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
