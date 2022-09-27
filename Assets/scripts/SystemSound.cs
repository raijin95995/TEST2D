using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class SystemSound : MonoBehaviour
{
    public static SystemSound instance;


    private AudioSource aud;

    private void Awake()
    {
        instance = this;
        aud = GetComponent<AudioSource>();
    }


    /// <summary>
    /// 播放音效的API
    /// </summary>
    /// <param name="sound">音效檔案</param>
    /// <param name="rangeVolume">音量範圍</param>
    public void PlaySound(AudioClip sound, Vector2 rangeVolume)
    {
        float volume = Random.Range(rangeVolume.x, rangeVolume.y);

        aud.PlayOneShot(sound, volume);

    }

}





