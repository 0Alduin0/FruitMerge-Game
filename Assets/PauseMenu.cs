using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;


    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
