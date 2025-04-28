using System.Collections.Generic;
using UnityEngine;

public class FruitDrop : MonoBehaviour
{
    public static FruitDrop Instance;
    private void Awake()
    {
        Instance = this;
    }

    [System.Serializable] // Inspector'da g�r�nebilir hale getirir
    public class WeightedFruit
    {
        public GameObject fruitPrefab;
        public float spawnWeight; // Spawn olas�l���n� belirler (�rne�in: elma=5, �ilek=1)
    }

    public List<WeightedFruit> weightedFruits; // A��rl�kl� meyve listesi
    public float dropHeight = 5f;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;

    private GameObject currentFruit;
    private Camera mainCamera;
    private bool canDrop = true;

    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewFruit();
    }

    void Update()
    {
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
        if (weightedFruits.Count == 0) return;

        // Toplam a��rl��� hesapla
        float totalWeight = 0f;
        foreach (var weightedFruit in weightedFruits)
        {
            totalWeight += weightedFruit.spawnWeight;
        }

        // Rastgele bir de�er se� (0 ile totalWeight aras�nda)
        float randomValue = Random.Range(0f, totalWeight);
        float weightSum = 0f;

        GameObject selectedFruit = null;

        // Hangi meyvenin se�ilece�ini belirle
        foreach (var weightedFruit in weightedFruits)
        {
            weightSum += weightedFruit.spawnWeight;
            if (randomValue <= weightSum)
            {
                selectedFruit = weightedFruit.fruitPrefab;
                break;
            }
        }

        if (selectedFruit == null)
        {
            selectedFruit = weightedFruits[0].fruitPrefab; // Fallback
        }

        // Yeni meyveyi olu�tur
        Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        spawnPosition.y = dropHeight;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, leftBoundary, rightBoundary);

        currentFruit = Instantiate(selectedFruit, spawnPosition, Quaternion.identity);
        currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0f;
        canDrop = true;
    }

    void DropFruit()
    {
        if (currentFruit.GetComponent<Rigidbody2D>() != null)
        {
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }

        canDrop = false;
        currentFruit = null;
        Invoke("SpawnNewFruit", 0.5f);
    }
}