using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs; // Sýralý: Blueberry, Grapes, Banana, Apple, Orange, Pear, Strawberry

    private Dictionary<string, GameObject> mergeHierarchy;

    public GameObject mergeEffect;
    public AudioManager audioManager;



    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        InitializeMergeHierarchy();
    }
    private void InitializeMergeHierarchy()
    {
        mergeHierarchy = new Dictionary<string, GameObject>()
        {
            {"Plum", fruitPrefabs[1]},    // Blueberry -> Grapes
            {"Strawberry", fruitPrefabs[2]},       // Grapes -> Banana
            {"Grapes", fruitPrefabs[3]},      // Banana -> Apple
            {"Lemon", fruitPrefabs[4]},       // Apple -> Orange
            {"Apple", fruitPrefabs[5]},       // Orange -> Pear
            {"Orange", fruitPrefabs[6]},        // Pear -> Strawberry
            {"Peach", fruitPrefabs[7]},        // Pear -> Strawberry
            {"Coconut", fruitPrefabs[8]},        // Pear -> Strawberry
            {"Watermelon", null}        // Pear -> Strawberry
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string currentTag = gameObject.tag;
        string otherTag = collision.gameObject.tag;

        if (currentTag == otherTag && mergeHierarchy.ContainsKey(currentTag))
        {
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                audioManager.PlaySFX(audioManager.mergeSFX);

                Vector2 mergePosition = (transform.position + collision.transform.position) / 2;

                ScoreManagement.Instance.AddScore(gameObject.tag);

                Destroy(collision.gameObject);
                Destroy(gameObject);
                GameObject smokeEffect = Instantiate(mergeEffect, mergePosition, Quaternion.identity);
                Destroy(smokeEffect, 3f);
                GameObject nextFruit = mergeHierarchy[currentTag];
                if (nextFruit != null)
                {
                    GameObject instantiateFruit = Instantiate(nextFruit, mergePosition, Quaternion.identity);
                    GameObject bowl = GameObject.FindGameObjectWithTag("Bowl");
                    instantiateFruit.transform.SetParent(bowl.transform);
                }
            }
        }
    }
}