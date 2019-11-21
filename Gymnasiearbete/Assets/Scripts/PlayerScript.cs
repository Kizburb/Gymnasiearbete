using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;

    // Start is called each time the game is run
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, 1);
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(1, 0, 0);
        }
    }
}
