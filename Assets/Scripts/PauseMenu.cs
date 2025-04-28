using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        FruitDrop.Instance.enabled = false;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
