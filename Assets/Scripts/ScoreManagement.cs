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
        {"Plum",50},
        {"Strawberry", 100},
        {"Grapes", 200},
        {"Lemon", 250},
        {"Apple", 400},
        {"Orange", 450},
        {"Peach", 500},
        {"Coconut", 700},
        {"Watermelon", 1000},
    };

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        scoreAdjustment();
    }
    public void scoreAdjustment()
    {
        score = 0;
        scoreText.text = score.ToString();
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