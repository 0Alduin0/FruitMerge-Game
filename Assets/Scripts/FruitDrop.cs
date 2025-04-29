using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FruitDrop : MonoBehaviour
{
    public static FruitDrop Instance;
    private void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    public class WeightedFruit
    {
        public GameObject fruitPrefab;
        public float spawnWeight;
    }

    public List<WeightedFruit> weightedFruits;
    public float dropHeight = 5f;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;

    private GameObject currentFruit;
    private Camera mainCamera;
    private bool canDrop = true;
    public bool hasGameStarted = false;

    void Start()
    {
        mainCamera = Camera.main;
    }
    public void StartNewGame()
    {
        clearAllFruits();

        if (currentFruit != null)
        {
            Destroy(currentFruit);
            currentFruit = null;
        }

        Time.timeScale = 1f;
        hasGameStarted = true;
        SpawnNewFruit();
        CancelInvoke("SpawnNewFruit");
        ScoreManagement.Instance.scoreAdjustment();
    }

    public void clearAllFruits()
    {
        GameObject bowl = GameObject.FindGameObjectWithTag("Bowl");
        foreach (Transform child in bowl.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void Update()
    {
        if (!hasGameStarted) return;

        if (currentFruit == null && !IsInvoking("SpawnNewFruit"))
        {
            Invoke("SpawnNewFruit", 0.5f);
        }

        if (currentFruit != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            float clampedX = Mathf.Clamp(worldPosition.x, leftBoundary, rightBoundary);
            currentFruit.transform.position = new Vector3(clampedX, currentFruit.transform.position.y, 0f);

            if (Input.GetMouseButtonDown(0) && canDrop)
            {
                DropFruit();
            }
        }
    }

    void SpawnNewFruit()
    {
        if (weightedFruits.Count == 0 || currentFruit != null) return;

        float totalWeight = weightedFruits.Sum(w => w.spawnWeight);
        float randomValue = Random.Range(0f, totalWeight);
        float weightSum = 0f;

        GameObject selectedFruit = weightedFruits[0].fruitPrefab; // Varsayýlan

        foreach (var weightedFruit in weightedFruits)
        {
            weightSum += weightedFruit.spawnWeight;
            if (randomValue <= weightSum)
            {
                selectedFruit = weightedFruit.fruitPrefab;
                break;
            }
        }

        Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        spawnPosition.y = dropHeight;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, leftBoundary, rightBoundary);

        currentFruit = Instantiate(selectedFruit, spawnPosition, Quaternion.identity);
        GameObject bowl = GameObject.FindGameObjectWithTag("Bowl");
        currentFruit.transform.SetParent(bowl.transform);
        currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0f;
        canDrop = true;
    }

    void DropFruit()
    {
        if (currentFruit == null) return;

        if (currentFruit.GetComponent<Rigidbody2D>() != null)
        {
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }

        canDrop = false;
        currentFruit = null;
    }
}