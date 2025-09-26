using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadSceneAsync("Main");
    }
    public void Exitgame()
    {
        Application.Quit();
    }
}
