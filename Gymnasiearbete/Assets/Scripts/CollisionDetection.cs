using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    // Skapar en Rigidbody variabel för att kunna ändra spelarens egenskaper när spelaren kolliderar med ett hinder.
    public Rigidbody playerRB;

    // Skapar en variabel av klassen PlayerScript för att kunna ta bort alla krafter efter spelaren kolliderat med ett hinder.
    public PlayerScript ps;

    // Blir kallad varje gång objektet kommer i kontakt (kolliderar) med ett annat objekt.
    void OnCollisionEnter (Collision collisionData)
    {
        if (collisionData.collider.tag == "Obstacle") // Om taggen på föremålet som spelaren kolliderar med är "Obstacle" så kör koden nedan.
        {
            playerRB.useGravity = false; // Stänger av gravitationen så att spelaren flyter iväg upp i luften efter att ha kolliderat med ett hinder.
            ps.turnForce = 0; // Stoppar rörelse åt sidorna även om spelaren trycker på knapparna 'A' eller 'D'.
            ps.forwardForce = 0; // Stoppar accelerationen framåt.
            Invoke("resetScene", 2); // Väntar 2 sekunder sen kör funktionen med namnet "resetScene".
        }

        // Om taggen på föremålet som spelaren kolliderar med är "Ramp" så lägg till en kraft på spelaren så spelaren inte tappar fart i hoppen.
        if (collisionData.collider.tag == "Ramp")
        {
            playerRB.AddForce(0, 0, 10000 * Time.deltaTime);
        }
    }

    void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Laddar scenen med den nuvarande scenens buildIndex, dvs. den laddar om den nuvarande scenen.
    }
}
