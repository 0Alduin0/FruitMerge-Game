using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{

    public AudioMixer audioMixer; // Inspector'dan atayacaðýnýz AudioMixer
    private bool isMuted = false;
    private float originalVolume;

    private void Start()
    {
        // Baþlangýçta ses seviyesini al (varsayýlan olarak 0 dB kabul ediyoruz)
        audioMixer.GetFloat("masterVolume", out originalVolume);
    }

    public void ToggleMasterVolume()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            // Sesleri kapat (sessiz seviye genellikle -80 dB'dir)
            audioMixer.SetFloat("masterVolume", -80f);
        }
        else
        {
            // Sesleri aç (orijinal seviyeye döndür)
            audioMixer.SetFloat("masterVolume", originalVolume);
        }
    }
}
