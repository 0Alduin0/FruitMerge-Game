using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitDrop : MonoBehaviour
{
  
    public List<GameObject> fruitPrefabs; // Farkl� meyve prefab'lar�
    public float dropHeight = 5f; // Meyvenin d��me y�ksekli�i

    private GameObject currentFruit; // �u anki kontrol edilen meyve
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
            mousePosition.z = 10f; // Kameradan uzakl�k
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            // Meyveyi fare ile hareket ettir (sadece x ekseninde)
            currentFruit.transform.position = new Vector3(worldPosition.x, currentFruit.transform.position.y, 0f);

            // Sol t�kla meyveyi b�rak
            if (Input.GetMouseButtonDown(0) && canDrop)
            {
                DropFruit();
            }
        }
    }

    void SpawnNewFruit()
    {
        if (fruitPrefabs.Count == 0) return;

        // Rastgele bir meyve se�
        int randomIndex = Random.Range(0, fruitPrefabs.Count);
        GameObject fruitPrefab = fruitPrefabs[randomIndex];

        // Fare pozisyonunda yeni meyve olu�tur
        Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        spawnPosition.y = dropHeight;

        currentFruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
        currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0f;
        canDrop = true;
    }

    void DropFruit()
    {
        // Yer�ekimi etkinle�tir
        if (currentFruit.GetComponent<Rigidbody2D>() != null)
        {
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        canDrop = false;
        currentFruit = null;

        // Yeni meyve i�in bekle
        Invoke("SpawnNewFruit", 0.5f);
    }
}
