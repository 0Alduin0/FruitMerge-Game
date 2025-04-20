using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitDrop : MonoBehaviour
{
  
    public List<GameObject> fruitPrefabs; // Farklý meyve prefab'larý
    public float dropHeight = 5f; // Meyvenin düþme yüksekliði

    private GameObject currentFruit; // Þu anki kontrol edilen meyve
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
            // Fare pozisyonunu takip et
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Kameradan uzaklýk
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            // Meyveyi fare ile hareket ettir (sadece x ekseninde)
            currentFruit.transform.position = new Vector3(worldPosition.x, currentFruit.transform.position.y, 0f);

            // Sol týkla meyveyi býrak
            if (Input.GetMouseButtonDown(0) && canDrop)
            {
                DropFruit();
            }
        }
    }

    void SpawnNewFruit()
    {
        if (fruitPrefabs.Count == 0) return;

        // Rastgele bir meyve seç
        int randomIndex = Random.Range(0, fruitPrefabs.Count);
        GameObject fruitPrefab = fruitPrefabs[randomIndex];

        // Fare pozisyonunda yeni meyve oluþtur
        Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        spawnPosition.y = dropHeight;

        currentFruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
        currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0f;
        canDrop = true;
    }

    void DropFruit()
    {
        // Yerçekimi etkinleþtir
        if (currentFruit.GetComponent<Rigidbody2D>() != null)
        {
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        canDrop = false;
        currentFruit = null;

        // Yeni meyve için bekle
        Invoke("SpawnNewFruit", 0.5f);
    }
}
