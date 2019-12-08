using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Skapar en Rigidbody variabel för att kunna ändra spelarens egenskaper när spelaren kolliderar med ett hinder.
    public Rigidbody playerRB;

    // Skapar en variabel av klassen PlayerScript för att kunna ta bort alla krafter efter spelaren kolliderat med ett hinder.
    public PlayerScript ps;

    // Blir kallad varje gång objektet kommer i kontakt (kolliderar) med ett annat objekt.
    void OnCollisionEnter (Collision collisionData)
    {
        if (collisionData.collider.tag == "Obstacle")
        {
            playerRB.useGravity = false;
            ps.turnForce = 0;
            ps.forwardForce = 0;
        }
    }
}
