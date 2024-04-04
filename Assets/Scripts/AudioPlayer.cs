using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [Header("Shooting")]
    [SerializeField] AudioClip shoothingAudio;
    [SerializeField][Range(0f, 1f)] float Shootingvolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageAudio;
    [SerializeField][Range(0f, 1f)] float Damagevolume = 1f;

    public void playShootingClip()
    {
        if (shoothingAudio != null)
        {
            AudioSource.PlayClipAtPoint(shoothingAudio, Camera.main.transform.position, Shootingvolume);
        }
    }

    public void playDamageClip()
    {
        if (damageAudio != null)
        {
            AudioSource.PlayClipAtPoint(damageAudio, Camera.main.transform.position, Damagevolume);
        }
    }


}
