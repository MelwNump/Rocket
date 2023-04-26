using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    private Rigidbody2D myBody;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Get joystick input and move player left or right
        float horizontalInput = joystick.Horizontal;
        Vector2 move = new Vector2(horizontalInput, 0f);
        myBody.velocity = move * moveSpeed;

        // Handle gravity and collisions using Rigidbody2D component
    }
}