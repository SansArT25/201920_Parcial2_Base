using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private Text currentTag, player1Score, player2Score, player3Score, player4Score, player1Place, player2Place, player3Place, player4Place, player1WinnerScore, player2WinnerScore, player3WinnerScore, player4WinnerScore, winner;

    [SerializeField]
    private GameObject results, gameplay;

    private bool done = false;

    private string winnerText = "Winner:";

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.Playing)
        {
            currentTag.text = GameController.Instance.TaggedPlayer.name;
            player1Score.text = GameController.Instance.TaggedScore["Player1"].ToString();
            player2Score.text = GameController.Instance.TaggedScore["Player2"].ToString();
            player3Score.text = GameController.Instance.TaggedScore["Player3"].ToString();
            player4Score.text = GameController.Instance.TaggedScore["Player4"].ToString();
        }
        else if(!done)
        {
            gameplay.SetActive(false);
            results.SetActive(true);
            player1WinnerScore.text = GameController.Instance.TaggedScore["Player1"].ToString();
            player2WinnerScore.text = GameController.Instance.TaggedScore["Player2"].ToString();
            player3WinnerScore.text = GameController.Instance.TaggedScore["Player3"].ToString();
            player4WinnerScore.text = GameController.Instance.TaggedScore["Player4"].ToString();
            player1Place.text = GetPlace(1).ToString();
            player2Place.text = GetPlace(2).ToString();
            player3Place.text = GetPlace(3).ToString();
            player4Place.text = GetPlace(4).ToString();
            winner.text = winnerText;
            done = true;
        }
    }

    private int GetPlace(int number)
    {
        int place = 1;
        if(number == 1)
        {
            if(GameController.Instance.TaggedScore["Player1"] > GameController.Instance.TaggedScore["Player2"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player1"] > GameController.Instance.TaggedScore["Player3"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player1"] > GameController.Instance.TaggedScore["Player4"])
            {
                place++;
            }

            if(place == 1)
            {
                winnerText += " Player1";
            }
        }
        else if (number == 2)
        {
            if (GameController.Instance.TaggedScore["Player2"] > GameController.Instance.TaggedScore["Player1"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player2"] > GameController.Instance.TaggedScore["Player3"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player2"] > GameController.Instance.TaggedScore["Player4"])
            {
                place++;
            }

            if (place == 1)
            {
                winnerText += " Player2";
            }
        }
        else if (number == 3)
        {
            if (GameController.Instance.TaggedScore["Player3"] > GameController.Instance.TaggedScore["Player2"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player3"] > GameController.Instance.TaggedScore["Player1"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player3"] > GameController.Instance.TaggedScore["Player4"])
            {
                place++;
            }

            if (place == 1)
            {
                winnerText += " Player3";
            }
        }
        else if (number == 4)
        {
            if (GameController.Instance.TaggedScore["Player4"] > GameController.Instance.TaggedScore["Player2"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player4"] > GameController.Instance.TaggedScore["Player3"])
            {
                place++;
            }
            if (GameController.Instance.TaggedScore["Player4"] > GameController.Instance.TaggedScore["Player1"])
            {
                place++;
            }

            if (place == 1)
            {
                winnerText += " Player4";
            }
        }
        return place;
    }
}