using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    public GameObject endGameUI;

    // När spelaren åker in i målet, anropa winGame funktionen.
    void OnTriggerEnter()
    {
        winGame();
    }

    // Gör så att rutan när du vinner spelet visas.
    void winGame()
    {
        endGameUI.SetActive(true);
    }
}
