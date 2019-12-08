using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Lagrar spelobjekten för spelaren för att kunna manipulera bl.a. position.
    public GameObject player;

    // Skapar en tredimensionell vektor för att kunna lagra avståndet mellan spelaren och kameran.
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Letar efter ett spelobjekt med namn "Player", sen sätter GameObject variabeln till detta objekt.
        player = GameObject.Find("Player");

        // Räkna ut och lagra offset (avståndsvariabeln) värdet genom att hämta avståndet mellan spelarens position och kamerans position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate blir kallad efter Update funktionen varje frame.
    void LateUpdate()
    {
        // Sätt positionen av kamerans transform till samma som spelarens men lägger till avståndsvariabeln.
        transform.position = player.transform.position + offset;
    }
}
