using UnityEngine;
using TMPro;

public class HighScoreTimer : MonoBehaviour
{
    public static HighScoreTimer highScoreSystem;
    public int bonusScore = 300;
    public float secondsTimer = 1f;
    public float nextSecond = 0f;
    public float resetSecond = 1f;
    public float nextResetSecond = 0f;
    public TextMeshProUGUI secondsText;
    public LevelPass manager;
    private void Awake()
    {
        highScoreSystem = this;
        GetComponent<PlayerHighScore>();
    }
    void Update()
    {
        if(manager.gameState %2 == 1)//checks if the game state is uneven
        {
            if (Time.time > nextSecond)
            {
                nextSecond = Time.time + secondsTimer;
                bonusScore -= 1;
                secondsText.text = bonusScore.ToString();
            }
        }
        if (manager.gameState %2 == 0)//checks if the game state is even
        {
            if(Time.time > nextResetSecond)
            {
                PlayerHighScore.pointsSystem.currentScore += bonusScore;
                manager.gameState += 1;
                bonusScore = 300;
            }
        }
    }
    public void StartBonusScoreAdd()
    {
        manager.gameState += 1;
        nextResetSecond = Time.time + resetSecond;
    }
}
