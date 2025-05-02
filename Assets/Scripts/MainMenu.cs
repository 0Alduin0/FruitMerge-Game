using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;


    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        FruitDrop.Instance.clearAllFruits();
        FruitDrop.Instance.StartNewGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
