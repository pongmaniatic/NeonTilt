using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScoreLeaderboard : MonoBehaviour
{
    public HighScoreCard[] playerNames;
    public TextMeshProUGUI[] highScoreNamesText;
    public TextMeshProUGUI[] highScorePointsText;
    public TMP_InputField inputField;
    public Button saveButton;
    private HighScoreCard defaultCard = new HighScoreCard("default", 0);//here we write the name of the developers and their scores in their own score card.
    private HighScoreCard esteban = new HighScoreCard("Esteban", 3753161);
    private HighScoreCard simon = new HighScoreCard("Simon", 3642783);
    private HighScoreCard johan = new HighScoreCard("Johan", 3189912);
    private HighScoreCard jenny = new HighScoreCard("Jenny", 2530251);
    private HighScoreCard lina = new HighScoreCard("Lina", 1789730);
    private HighScoreCard mojmir = new HighScoreCard("Mojmir", 1204401);
    private HighScoreCard sofie = new HighScoreCard("Sofie", 1202210);
    private HighScoreCard mikael = new HighScoreCard("Mikael", 100006);
    private HighScoreCard monireh = new HighScoreCard("Monireh", 84250);
    private HighScoreCard ben = new HighScoreCard("Ben", 75382);
    private List<HighScoreCard> allCards = new List<HighScoreCard>();
    private string playerNameString;
    private List<HighScoreCard> newAllCards = new List<HighScoreCard>();
    private int playerScore;
    private string playerName;


    void Awake()
    {
        playerScore = PlayerPrefs.GetInt("playerscore");
        playerName = PlayerPrefs.GetString("playerName");
        allCards.Add(esteban);
        allCards.Add(simon);
        allCards.Add(johan);
        allCards.Add(jenny);
        allCards.Add(lina);
        allCards.Add(ben);
        allCards.Add(sofie);
        allCards.Add(mikael);
        allCards.Add(mojmir);
        allCards.Add(monireh);
        foreach (var card in allCards)
        {
            newAllCards.Add(card);
        }
        CompareCards(newAllCards);// this takes a list of cards and compares them and puts the higest into a new list until there are no more cards left.
    }
    public void savePlayerScore()// this is suppose to be called when the player clicks to save their score and name.
    {
        playerNameString = inputField.text;

        if (playerScore < PlayerHighScore.pointsSystem.currentScore)
        {
            PlayerPrefs.SetString("playerName", playerNameString);
            PlayerPrefs.SetInt("playerscore", PlayerHighScore.pointsSystem.currentScore); 
            PlayerPrefs.Save();
        }
        playerScore = PlayerPrefs.GetInt("playerscore");
        playerName = PlayerPrefs.GetString("playerName");

        HighScoreCard player = new HighScoreCard(playerName, playerScore);
        allCards.Add(player);        
        foreach (var card in allCards)
        {
            newAllCards.Add(card);
        }
        CompareCards(newAllCards);
        Debug.Log(allCards.Count);
    }

    void CompareCards(List<HighScoreCard> newAllCards)// this is the function that compares the score cards among themselves.
    {
        List<HighScoreCard> UltimateCardListInOrder = new List<HighScoreCard>();// this is the list where all the cards will go in order.

        int listLenght = newAllCards.Count;
        while ( listLenght > 0)
        {
            HighScoreCard bestCard = defaultCard;
            foreach (var card in newAllCards)
            {
                if (card.score > bestCard.score)
                {
                    bestCard = card;
                }
            }
            UltimateCardListInOrder.Add(bestCard);
            newAllCards.Remove(bestCard);
            listLenght = newAllCards.Count;
        }

        int ultimateListLenght = UltimateCardListInOrder.Count;
        for (int i = 0; i < ultimateListLenght; i++)// this 2 will go through all the cards in order of score.
        {
            highScoreNamesText[i].text = UltimateCardListInOrder[i].playerName;
        }
        for (int i = 0; i < ultimateListLenght; i++)
        {
            string scoreString = UltimateCardListInOrder[i].score.ToString();
            string someString = scoreString.PadLeft(10, '0');// this is what adds the 00 to the left of the score text.
            highScorePointsText[i].text = someString;
        }
    }

    private void Update()
    {
        if (inputField.text == "") { saveButton.interactable = false; } else { saveButton.interactable = true; };
    }

}

public struct HighScoreCard //this is the struction of a score card, it holds the name of a person and its score.
{
    public string playerName;
    public int score;

    public HighScoreCard(string playerName1, int score1)
    {
        playerName = playerName1;
        score = score1;
    }
}
