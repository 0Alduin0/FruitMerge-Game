using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement Instance;
    public float score = 0;
    public TextMeshProUGUI scoreText;


    // Meyve tag'lerine göre puanlar
    private Dictionary<string, int> fruitScores = new Dictionary<string, int>()
    {
        {"Blueberry", 50},
        {"Grapes", 100},
        {"Banana", 150},
        {"Apple", 200},
        {"Orange", 250},
        {"Pear", 300},
        {"Strawberry", 500}
    };

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        Debug.Log(score);
    }
    // Diðer script'lerden çaðýrýlacak metod
    public void AddScore(string fruitTag)
    {
        if (fruitScores.ContainsKey(fruitTag))
        {
            score += fruitScores[fruitTag];
            scoreText.text = score.ToString();
        }
    }
}