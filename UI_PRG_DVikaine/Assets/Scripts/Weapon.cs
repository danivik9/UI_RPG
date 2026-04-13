using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float minDamage, maxDamage;
    public string weaponName;
    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    public virtual float GetDamage()
    {
        return Random.Range(minDamage, maxDamage);
    }
}