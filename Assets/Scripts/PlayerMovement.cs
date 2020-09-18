using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = default;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0f, 1000f, 0f));
                //transform.position += Vector3.back * speed * Time.deltaTime;
            }
    #endif
    }

    void FixedUpdate()
    {
        float xVel = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(xVel * speed * Time.deltaTime, rb.velocity.y, 0);
    }
}
