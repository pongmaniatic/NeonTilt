using UnityEngine;
using TMPro;


public class UltimateGlobalTimer : MonoBehaviour
{
    public static UltimateGlobalTimer ultimateGlobalTimer;
    private float secondsTimer = 1f;
    private float nextSecond = 0f;
    public TextMeshProUGUI secondsText;
    public TextMeshProUGUI minutesText;
    public LevelPass manager;
    private int minutes = 0;
    public int seconds = 300;
    public GameObject leaderBoardMenu;
    public Rigidbody ball;

    private void Awake()
    {
        ultimateGlobalTimer = this;
    }

    void Update()
    {

        //if (UltimateGameManager.ultimateGameManager.menuMode == true)
        //{
            if (minutes < 1 && seconds < 1)
            {
                leaderBoardMenu.SetActive(true);
                secondsText.text = "00";
                minutesText.text = "0";
                ball.velocity = new Vector3(0, 0, 0);
                ball.freezeRotation = true;
                ball.constraints = RigidbodyConstraints.FreezeRotationX
                    | RigidbodyConstraints.FreezeRotationY
                    | RigidbodyConstraints.FreezeRotationZ
                    | RigidbodyConstraints.FreezePositionX
                    | RigidbodyConstraints.FreezePositionY
                    | RigidbodyConstraints.FreezePositionZ;

            }
            else
            {
                if (Time.time > nextSecond)
                {
                    nextSecond = Time.time + secondsTimer;
                    seconds -= 1;
                    while (seconds > 60)
                    {
                        seconds -= 60;
                        minutes += 1;
                    }

                    if (seconds < 0)
                    {
                        seconds += 60;
                        minutes -= 1;
                    }
                    if (seconds < 10)
                    {
                        secondsText.text = "0" + seconds.ToString();
                    }
                    else
                    {
                        secondsText.text = seconds.ToString();
                    }
                    minutesText.text = minutes.ToString();
                }
            }

       // }


    }

    public void LoseTime(int lostTime)
    {
        seconds -= lostTime;
    }

    public void SetTime()
    {
        minutes = 5;
        seconds = 0;
    }
}
