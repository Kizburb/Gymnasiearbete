using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Om användaren trycker på "exit" knappen, kör denna funktion
    public void quitGame()
    {
        Application.Quit(); // Stänger av spelapplikationen
    }

    // Om användaren trycker på "play again" knappen, kör den här funktionen
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Startar om scenen likadant som när vi kolliderar med hindren på banan.
    }
}
