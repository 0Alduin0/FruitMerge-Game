using System;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public float score;
    private void Start()
    {
        score = 0;
    }

    [SerializeField] private GameObject apple;
    [SerializeField] private GameObject banana;
    [SerializeField] private GameObject blueberry;
    [SerializeField] private GameObject grapes;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject pear;
    [SerializeField] private GameObject strawberry;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Blueberry") && gameObject.tag == "Blueberry")
        {
            score = score + 100;
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Vector2 firstFruit = transform.position;
                Vector2 secondFruit = collision.transform.position;
                Vector2 pozisyon = (firstFruit + secondFruit) / 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                Instantiate(grapes, pozisyon, Quaternion.identity);
            }
        }

        if (collision.transform.CompareTag("Grapes") && gameObject.tag == "Grapes")
        {
            score = score + 100;
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Vector2 firstFruit = transform.position;
                Vector2 secondFruit = collision.transform.position;
                Vector2 pozisyon = (firstFruit + secondFruit) / 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                Instantiate(banana, pozisyon, Quaternion.identity);
            }
        }

        if (collision.transform.CompareTag("Banana") && gameObject.tag == "Banana")
        {
            score = score + 100;
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Vector2 firstFruit = transform.position;
                Vector2 secondFruit = collision.transform.position;
                Vector2 pozisyon = (firstFruit + secondFruit) / 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                Instantiate(apple, pozisyon, Quaternion.identity);
            }
        }

        if (collision.transform.CompareTag("Apple") && gameObject.tag == "Apple")
        {
            score = score + 100;
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Vector2 firstFruit = transform.position;
                Vector2 secondFruit = collision.transform.position;
                Vector2 pozisyon = (firstFruit + secondFruit) / 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                Instantiate(orange, pozisyon, Quaternion.identity);
            }
        }

        if (collision.transform.CompareTag("Orange") && gameObject.tag == "Orange")
        {
            score = score + 100;
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Vector2 firstFruit = transform.position;
                Vector2 secondFruit = collision.transform.position;
                Vector2 pozisyon = (firstFruit + secondFruit) / 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                Instantiate(pear, pozisyon, Quaternion.identity);
            }
        }

        if (collision.transform.CompareTag("Pear") && gameObject.tag == "Pear")
        {
            score = score + 100;
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Vector2 firstFruit = transform.position;
                Vector2 secondFruit = collision.transform.position;
                Vector2 pozisyon = (firstFruit + secondFruit) / 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                Instantiate(strawberry, pozisyon, Quaternion.identity);
            }
        }

        if (collision.transform.CompareTag("Strawberry") && gameObject.tag == "Strawberry")
        {
            score = score + 100;
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        print(score);
    }
}