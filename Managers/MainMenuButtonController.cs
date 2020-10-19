using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){QuitGame();}
        if (Input.GetKeyDown(KeyCode.R)){RestartGame();}
    }
    public static void RestartGame(){SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
    public static void QuitGame(){Application.Quit();}
    public static void LoadPlayLevel(){SceneManager.LoadScene(1);}
}
