using UnityEngine;

public class EstebanGameManager : MonoBehaviour
{
    public static EstebanGameManager estebanGameManager;
    public bool menuMode;// true means menu mode, and false means game mode.
    public GameObject cameraMenu;// this camera is active in menu Mode
    public GameObject cameraGame;// this camera is active in game Mode
    public int gameTime = 300;

    public GameObject menuPanel;// this camera is active in menu Mode
    public GameObject gamePanel;// this camera is active in game Mode

    void Awake() { estebanGameManager = this; }

    public void Updatemode() 
    {
        menuMode = !menuMode;
        GlobalTimer.GlobalTimerSystem.seconds = gameTime;
    }

    public void ResetTheGame()
    {
        GlobalTimer.GlobalTimerSystem.seconds = gameTime;
    }


}
