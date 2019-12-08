using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Skapar en Rigidbody variabel för att senare kunna hantera spelarens rörelser.
    public Rigidbody playerRB;

    // Skapar 2 kraftvariabler för att lättare kunna ändra spelarens rörelser.
    public float turnForce, forwardForce;

    // Start is called each time the game is run
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Lagrar spelarens Rigidbody egenskap vilket låter oss manipulera objektets hastighet, riktning etc.
    }

    // Update is called once per frame
    void Update()
    {
        // Ger spelaren en kraft framåt hela tiden oavsett om spelaren trycker på någon knapp.
        playerRB.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Om spelaren trycker A eller D, ge en kraft åt sidorna för att kunna undvika hinder.
        if (Input.GetKey(KeyCode.A)) // A = Sväng vänster
        {
            playerRB.AddForce(-turnForce, 0, 0); // Lägger till en negativ kraft på x-ledet vilket i detta fall är åt vänster.
        }
        else if (Input.GetKey(KeyCode.D)) // D = Sväng höger
        {
            playerRB.AddForce(turnForce, 0, 0); // Lägger till en positiv kraft på x-ledet vilket då är åt höger.
        }
    }
}
