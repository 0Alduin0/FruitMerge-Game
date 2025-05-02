using TMPro;
using UnityEngine;

public class FruitBorderControl : MonoBehaviour
{

    [Header("Ayarlar")]
    public float sayacSuresi = 3f; // Toplam sayac süresi (3 saniye)
    public TextMeshProUGUI sayacText; // Sayacý gösterecek UI Text (isteðe baðlý)

    public float anaSayacÖncesi = 2f;

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
            anaSayacÖncesi -= Time.deltaTime;
        }



        if (sayacAktif && anaSayacÖncesi <= 0)
        {
            countDownUI.SetActive(true);
            mevcutSayac -= Time.deltaTime;

            // UI Text güncelleme
            if (sayacText != null)
            {
                sayacText.text = Mathf.Ceil(mevcutSayac).ToString();
            }

            // Sayac tamamlandýðýnda
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
        anaSayacÖncesi = 2f;

        if (sayacText != null)
        {
            sayacText.text = "";
        }

    }
}
