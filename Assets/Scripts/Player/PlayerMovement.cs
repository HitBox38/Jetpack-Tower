using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jetForce = 5f;
    [SerializeField] private float moveSpeed = 2.5f;

    private Rigidbody2D rb;
    private SpriteRenderer jetBurst;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jetBurst = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 forceToApply = new Vector2(0, jetForce);
            rb.AddForce(forceToApply);

            jetBurst.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jetBurst.enabled = false;
        }

        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveDirection;
    }
}
