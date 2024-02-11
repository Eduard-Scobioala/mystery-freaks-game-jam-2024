using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 1);
        float sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

    public void OnMusicSliderValueChanged()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.musicSource.volume = musicSlider.value;
        }
    }

    public void OnSfxSliderValueChanged()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.sfxSource.volume = sfxSlider.value;
        }
    }
}
