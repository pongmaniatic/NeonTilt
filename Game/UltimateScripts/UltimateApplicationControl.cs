using UnityEngine;
using UnityEngine.SceneManagement;

public class UltimateApplicationControl : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject VolumeMenu2;
    public GameObject highScoreMenu;
    void Update()
    {
        if (highScoreMenu.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu")
            {
                TogglePause();
            }
        }
    }
    public void TogglePause()
    {
        if (VolumeMenu2.activeInHierarchy == true || pauseMenu.activeInHierarchy == true)
        {
            VolumeMenu2.SetActive(false);
            pauseMenu.SetActive(false);
        }
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }
    public static void RestartGame() { SceneManager.LoadScene(0); }
    public static void QuitGame() { Application.Quit(); }
    public static void LoadPlayLevel() { SceneManager.LoadScene(1); }
    public static void LoadMenu() { SceneManager.LoadScene(0); }
}
