using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs; // Sýralý: Blueberry, Grapes, Banana, Apple, Orange, Pear, Strawberry

    private Dictionary<string, GameObject> mergeHierarchy;
    private void Start()
    {
        InitializeMergeHierarchy();
    }
    private void InitializeMergeHierarchy()
    {
        mergeHierarchy = new Dictionary<string, GameObject>()
        {
            {"Blueberry", fruitPrefabs[1]},    // Blueberry -> Grapes
            {"Grapes", fruitPrefabs[2]},       // Grapes -> Banana
            {"Banana", fruitPrefabs[3]},      // Banana -> Apple
            {"Apple", fruitPrefabs[4]},       // Apple -> Orange
            {"Orange", fruitPrefabs[5]},       // Orange -> Pear
            {"Pear", fruitPrefabs[6]},        // Pear -> Strawberry
            {"Strawberry", null}             // Strawberry'nin sonrasý yok
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
                Vector2 mergePosition = (transform.position + collision.transform.position) / 2;

                ScoreManagement.Instance.AddScore(gameObject.tag);

                Destroy(collision.gameObject);
                Destroy(gameObject);

                GameObject nextFruit = mergeHierarchy[currentTag];
                if (nextFruit != null)
                {
                    Instantiate(nextFruit, mergePosition, Quaternion.identity);
                }
            }
        }
    }
}