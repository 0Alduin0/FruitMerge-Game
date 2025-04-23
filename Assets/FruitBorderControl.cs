using TMPro;
using UnityEngine;

public class FruitBorderControl : MonoBehaviour
{

    [Header("Ayarlar")]
    public float sayacSuresi = 3f; // Toplam sayac s�resi (3 saniye)
    public TextMeshProUGUI sayacText; // Sayac� g�sterecek UI Text (iste�e ba�l�)

    [Header("Debug")]
    [SerializeField] private float mevcutSayac;
    [SerializeField] private bool sayacAktif = false;
    [SerializeField] private GameObject temasEdenMeyve;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!sayacAktif)
        {
            temasEdenMeyve = other.gameObject;
            sayacAktif = true;
            mevcutSayac = sayacSuresi;

            Debug.Log("Meyve bardak a�z�na de�di, sayac ba�lad�!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == temasEdenMeyve)
        {
            SayaciSifirla();
        }
    }

    private void Update()
    {
        if (sayacAktif)
        {
            mevcutSayac -= Time.deltaTime;

            // UI Text g�ncelleme
            if (sayacText != null)
            {
                sayacText.text = Mathf.Ceil(mevcutSayac).ToString();
            }

            // Sayac tamamland���nda
            if (mevcutSayac <= 0)
            {
                SayaciSifirla();
            }
        }
    }

    private void SayaciSifirla()
    {
        sayacAktif = false;
        temasEdenMeyve = null;

        if (sayacText != null)
        {
            sayacText.text = "";
        }

        Debug.Log("Sayac s�f�rland�");
    }
}
