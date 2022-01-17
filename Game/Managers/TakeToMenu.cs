using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeToMenu : MonoBehaviour
{
 private void OnTriggerEnter(Collider other){SceneManager.LoadScene(0);}
}