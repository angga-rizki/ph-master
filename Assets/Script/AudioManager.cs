using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioSource musicPlayer;

    public AudioClip buttonSound;
    public AudioClip adukFinishSound;

    public AudioClip[] bgm;
    public AudioClip currentBgm;

    // Singleton Audio Manager
    public static AudioManager audioManager = null;

    private void Awake()
    {
        // Membaca value terakhir yang tersimpan
        float musicVolume = PlayerPrefs.GetFloat("music_volume", 1);
        float soundVolume = PlayerPrefs.GetFloat("sound_volume", 1);
        bool isMusicMute = PlayerPrefs.GetInt("music_mute", 0) == 1 ? true : false;
        bool isSoundMute = PlayerPrefs.GetInt("sound_mute", 0) == 1 ? true : false;

        // Mengatur setting audio berdasarkan value terakhir yang tersimpan
        ChangeVolumeMusic(musicVolume);
        ChangeVolumeSound(soundVolume);
        MuteMusic(isMusicMute);
        MuteSound(isSoundMute);
    }

    void Start()
    {
        // Membuat singleton Audio Manager
        if (audioManager == null)
        {
            audioManager = this;

            PlayMusic();

            DontDestroyOnLoad(gameObject);
        }
        else if (audioManager != this)
        {
            Destroy(this);
        }
    }

    public void ChangeVolumeMusic(float musicVolume)
    {
        PlayerPrefs.SetFloat("music_volume", musicVolume);
        musicPlayer.volume = PlayerPrefs.GetFloat("music_volume", 1);
    }

    public void ChangeVolumeSound(float soundVolume)
    {
        PlayerPrefs.SetFloat("sound_volume", soundVolume);
        soundPlayer.volume = PlayerPrefs.GetFloat("sound_volume", 1);
    }

    public void MuteMusic(bool isMusicMute)
    {
        PlayerPrefs.SetInt("music_mute", isMusicMute ? 1 : 0);
        musicPlayer.mute = PlayerPrefs.GetInt("music_mute", 0) == 1 ? true : false;        
    }

    public void MuteSound(bool isSoundMute)
    {
        PlayerPrefs.SetInt("sound_mute", isSoundMute ? 1 : 0);
        soundPlayer.mute = PlayerPrefs.GetInt("sound_mute", 0) == 1 ? true : false;        
    }

    public void AddButtonSound(GameObject[] button)
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Button>().onClick.AddListener(PlayButtonSound);
        }
    }

    public void PlayButtonSound()
    {
        soundPlayer.PlayOneShot(buttonSound);
    }

    void PlayMusic()
    {
        currentBgm = bgm[Random.Range(0, bgm.Length)];
        musicPlayer.PlayOneShot(currentBgm);

        Invoke("PlayMusic", currentBgm.length);
    }
}
