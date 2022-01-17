using UnityEngine;

public class UltimateGameManager : MonoBehaviour
{
    public static UltimateGameManager ultimateGameManager;
    public bool menuMode;// true means menu mode, and false means game mode.
    public GameObject cameraMenu;// this camera is active in menu Mode
    public GameObject cameraGame;// this camera is active in game Mode
    public int gameTime = 300;

    public GameObject menuPanel;// this camera is active in menu Mode
    public GameObject gamePanel;// this camera is active in game Mode

    void Awake() { ultimateGameManager = this; }

    public void Updatemode()
    {
        menuMode = !menuMode;
        UltimateGlobalTimer.ultimateGlobalTimer.seconds = gameTime;
    }

    public void ResetTheGame()
    {
        UltimateGlobalTimer.ultimateGlobalTimer.seconds = gameTime;
    }

}
