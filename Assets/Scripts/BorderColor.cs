using UnityEngine;
using UnityEngine.UI;

public class BorderColor : MonoBehaviour
{
    [Header("Ayarlar")]
    public float parlatmaHizi = 2f; // Renk de�i�im h�z�
    public float minParlaklik = 0.4f; // Minimum parlakl�k de�eri (0-1)
    public float maxParlaklik = 1f; // Maksimum parlakl�k de�eri (0-1)

    private Image imageComponent;
    private Color baslangicRengi;
    private float zamanSayaci = 0f;

    void Start()
    {
        imageComponent = GetComponent<Image>();
        baslangicRengi = imageComponent.color;
    }

    void Update()
    {
        // Zaman sayac�n� g�ncelle
        zamanSayaci += Time.deltaTime * parlatmaHizi;

        // Sin�s fonksiyonu ile dalgalanma efekti (0-1 aras�)
        float dalgalanma = Mathf.Sin(zamanSayaci) * 0.8f + 0.8f;

        // Parlakl�k de�erini hesapla (min ve max aras�nda)
        float parlaklik = Mathf.Lerp(minParlaklik, maxParlaklik, dalgalanma);

        // Yeni rengi uygula (alfa de�erini koruyarak)
        Color yeniRenk = new Color(
            baslangicRengi.r * parlaklik,
            baslangicRengi.g * parlaklik,
            baslangicRengi.b * parlaklik,
            baslangicRengi.a);

        imageComponent.color = yeniRenk;
    }
}
