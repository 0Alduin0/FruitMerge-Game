using TMPro;
using UnityEngine;

public class FruitBorderControl : MonoBehaviour
{

    [Header("Ayarlar")]
    public float sayacSuresi = 3f; // Toplam sayac s�resi (3 saniye)
    public TextMeshProUGUI sayacText; // Sayac� g�sterecek UI Text (iste�e ba�l�)

    public float anaSayac�ncesi = 2f;

    [Header("Debug")]
    [SerializeField] private float mevcutSayac;
    [SerializeField] private bool sayacAktif = false;
    [SerializeField] private bool ilkSayacAktif = false;
    [SerializeField] private GameObject temasEdenMeyve;

    public GameObject lostMenu;
    public GameObject countDownUI;

    private void Start()
    {
        countDownUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ilkSayacAktif == false)
        {
            temasEdenMeyve = other.gameObject;
            ilkSayacAktif = true;
        }
        if (sayacAktif == false)
        {
            temasEdenMeyve = other.gameObject;
            sayacAktif = true;
            mevcutSayac = sayacSuresi;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == temasEdenMeyve)
        {
            SayaciSifirla();
            ilkSayacAktif = false;
        }
    }

    private void Update()
    {
        if (ilkSayacAktif)
        {
            anaSayac�ncesi -= Time.deltaTime;
        }



        if (sayacAktif && anaSayac�ncesi <= 0)
        {
            countDownUI.SetActive(true);
            mevcutSayac -= Time.deltaTime;

            // UI Text g�ncelleme
            if (sayacText != null)
            {
                sayacText.text = Mathf.Ceil(mevcutSayac).ToString();
            }

            // Sayac tamamland���nda
            if (mevcutSayac <= 0)
            {
                Time.timeScale = 0f;
                lostMenu.SetActive(true);
            }
        }
    }

    private void SayaciSifirla()
    {
        sayacAktif = false;
        temasEdenMeyve = null;
        countDownUI.SetActive(false);
        anaSayac�ncesi = 2f;

        if (sayacText != null)
        {
            sayacText.text = "";
        }

    }
}
