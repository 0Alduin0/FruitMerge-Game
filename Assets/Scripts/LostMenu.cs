using UnityEngine;

public class LostMenu : MonoBehaviour
{
    public GameObject lostMenu;
    public void StartGame()
    {
        lostMenu.SetActive(false);
        FruitDrop.Instance.clearAllFruits();
        //FruitDrop.Instance.StartNewGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
