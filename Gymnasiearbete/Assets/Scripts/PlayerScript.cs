using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Skapar en Rigidbody variabel för att senare kunna hantera spelarens rörelser.
    public Rigidbody playerRB;

    // Skapar en textvariabel för att kunna ändra antalet poäng som visas i användargränssnittet.
    public Text scoreText;

    // Skapar 2 kraftvariabler för att lättare kunna ändra spelarens rörelser.
    public float turnForce, forwardForce;

    public int score; // Spelarens poäng

    // Start is called each time the game is run
    void Start()
    {
        score = 0;
        playerRB = GetComponent<Rigidbody>(); // Lagrar spelarens Rigidbody egenskap vilket låter oss manipulera objektets hastighet, riktning etc.
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)playerRB.position.z + 50; // Lägger till 51 eftersom spelarens startposition på z-ledet är -51.

        // Sätter scoreTexten till antalet poäng spelaren har.
        scoreText.text = score.ToString();

        // Ger spelaren en kraft framåt hela tiden oavsett om spelaren trycker på någon knapp.
        playerRB.AddForce(0, 0, forwardForce * Time.deltaTime); // Time.deltaTime är tiden mellan nuvarande frame och förra framen.

        // Om spelaren trycker A, D eller någon av höger eller vänster piltangenter, ge en kraft åt sidorna för att kunna undvika hinder.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // A = Sväng vänster || <- = Sväng vänster
        {
            playerRB.AddForce(-turnForce * Time.deltaTime, 0, 0); // Lägger till en negativ kraft på x-ledet vilket i detta fall är åt vänster.
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // D = Sväng höger || -> = Sväng höger
        {
            playerRB.AddForce(turnForce * Time.deltaTime, 0, 0); // Lägger till en positiv kraft på x-ledet vilket då är åt höger.
        }

        // Om spelarens position på Y-ledet är mindre än -3 och inte har nått målet, starta om scenen eftersom detta betyder att spelaren ramlat av banan.
        if (playerRB.position.y < -3 && playerRB.position.z < 150) 
        {
            resetScene();
        }
    }

    void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
