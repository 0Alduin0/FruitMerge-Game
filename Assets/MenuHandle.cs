using UnityEngine;

public class MenuHandle : MonoBehaviour
{
    public GameObject menuButton;
    public void PlayGame()
    {
        FruitDrop.Instance.enabled = true;
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        menuButton.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
