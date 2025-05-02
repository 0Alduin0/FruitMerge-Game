using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{

    public AudioMixer audioMixer; // Inspector'dan atayaca��n�z AudioMixer
    private bool isMuted = false;
    private float originalVolume;

    private void Start()
    {
        // Ba�lang��ta ses seviyesini al (varsay�lan olarak 0 dB kabul ediyoruz)
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
            // Sesleri a� (orijinal seviyeye d�nd�r)
            audioMixer.SetFloat("masterVolume", originalVolume);
        }
    }
}
