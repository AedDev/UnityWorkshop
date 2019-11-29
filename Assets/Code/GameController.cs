using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("References")]
    public Player playerOne;
    public Player playerTwo;

    [Header("UI")]
    public Text playerOneScore;
    public Text playerTwoScore;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (playerOne && playerOneScore)
            playerOneScore.text = playerOne.score.ToString();

        if (playerTwo && playerTwoScore)
            playerTwoScore.text = playerTwo.score.ToString();
    }
}
