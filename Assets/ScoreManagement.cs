using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public ScoreManagement Instance;
    public float score = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        Debug.Log(score);
    }

}
