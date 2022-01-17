using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHighScore : MonoBehaviour
{
    public static PlayerHighScore pointsSystem;
    public int currentScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highestScore;

    private void Awake(){pointsSystem = this;}
    private void Start(){highestScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();}
    private void Update(){score.text = currentScore.ToString();}

    public void AddScore(int points)
    {
        currentScore += points;
        if(currentScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            highestScore.text = currentScore.ToString();
        }
    }
}
