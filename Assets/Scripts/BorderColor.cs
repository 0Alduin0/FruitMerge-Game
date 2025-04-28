using UnityEngine;
using UnityEngine.UI;

public class BorderColor : MonoBehaviour
{
    [Header("Ayarlar")]
    public float parlatmaHizi = 2f; // Renk deðiþim hýzý
    public float minParlaklik = 0.4f; // Minimum parlaklýk deðeri (0-1)
    public float maxParlaklik = 1f; // Maksimum parlaklýk deðeri (0-1)

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
        // Zaman sayacýný güncelle
        zamanSayaci += Time.deltaTime * parlatmaHizi;

        // Sinüs fonksiyonu ile dalgalanma efekti (0-1 arasý)
        float dalgalanma = Mathf.Sin(zamanSayaci) * 0.8f + 0.8f;

        // Parlaklýk deðerini hesapla (min ve max arasýnda)
        float parlaklik = Mathf.Lerp(minParlaklik, maxParlaklik, dalgalanma);

        // Yeni rengi uygula (alfa deðerini koruyarak)
        Color yeniRenk = new Color(
            baslangicRengi.r * parlaklik,
            baslangicRengi.g * parlaklik,
            baslangicRengi.b * parlaklik,
            baslangicRengi.a);

        imageComponent.color = yeniRenk;
    }
}
