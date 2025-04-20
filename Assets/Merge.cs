using System;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private GameObject banana;
    [SerializeField] private GameObject blueberry;
    [SerializeField] private GameObject grapes;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject pear;
    [SerializeField] private GameObject strawberry;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Apple") && gameObject.tag == "Apple")
        {
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
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                Vector2 firstFruit = transform.position;
                Vector2 secondFruit = collision.transform.position;
                Vector2 pozisyon = (firstFruit + secondFruit) / 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                Instantiate(blueberry, pozisyon, Quaternion.identity);
            }
        }

        if (collision.transform.CompareTag("Blueberry") && gameObject.tag == "Blueberry")
        {
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
    }


}
