using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauser : MonoBehaviour
{
    public void OnPauseButton() {
        Time.timeScale = 0f;
    }

    public void OnResumeButton() {
        Time.timeScale = 1f;
    }

    public void OnRestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnMainMenuButton() {
        SceneManager.LoadScene("Menu");
    }
}
