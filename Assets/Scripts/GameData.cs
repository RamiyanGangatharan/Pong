using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GameData class is responsible for defining the data structure that holds 
 * the game-related data such as player scores. This class can be extended 
 * to include more game-related data as required.
 */
public class GameData : MonoBehaviour
{
    // The score of player 1
    public int player1Score;

    // The score of player 2
    public int player2Score;

    // Start is called before the first frame update.
    // This method is used for initialization.
    void Start()
    {
        // Initialize player scores or other game data here if needed.
        // For example, setting initial scores to 0.
        player1Score = 0;
        player2Score = 0;
    }

    // Update is called once per frame.
    // This method is used to update the state of the game data.
    void Update()
    {
        // Code to update game data every frame can be added here.
        // For example, listening for events that change the scores.
    }
}
