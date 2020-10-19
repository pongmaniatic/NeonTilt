using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplicationControls : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject highScoreMenu;
    void Update()
    {
        if(highScoreMenu.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu")
            {
                TogglePause();
            }
        }
    }
    public void TogglePause()
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }
    public static void RestartGame(){SceneManager.LoadScene(0);}
    public static void QuitGame(){Application.Quit();}
    public static void LoadPlayLevel(){SceneManager.LoadScene(1);}
    public static void LoadMenu() { SceneManager.LoadScene(0); }
}
