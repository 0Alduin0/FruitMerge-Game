using UnityEngine;

public class LostMenu : MonoBehaviour
{
    public GameObject lostMenu;
    public void NewGame()
    {
        lostMenu.SetActive(false);
        FruitDrop.Instance.StartGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
