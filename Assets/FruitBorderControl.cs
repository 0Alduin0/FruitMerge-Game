using TMPro;
using UnityEngine;

public class FruitBorderControl : MonoBehaviour
{

    [Header("Ayarlar")]
    public float sayacSuresi = 3f; // Toplam sayac süresi (3 saniye)
    public TextMeshProUGUI sayacText; // Sayacý gösterecek UI Text (isteðe baðlý)

    [Header("Debug")]
    [SerializeField] private float mevcutSayac;
    [SerializeField] private bool sayacAktif = false;
    [SerializeField] private GameObject temasEdenMeyve;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (sayacAktif == false)
        {
            temasEdenMeyve = other.gameObject;
            sayacAktif = true;
            mevcutSayac = sayacSuresi;

            Debug.Log("Meyve bardak aðzýna deðdi, sayac baþladý!");
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
            Debug.Log(Mathf.FloorToInt(mevcutSayac));

            // UI Text güncelleme
            if (sayacText != null)
            {
                sayacText.text = Mathf.Ceil(mevcutSayac).ToString();
            }

            // Sayac tamamlandýðýnda
            if (mevcutSayac <= 0)
            {
                Debug.Log("sayaç 0 oldu");
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

        Debug.Log("Sayac sýfýrlandý");
    }
}
