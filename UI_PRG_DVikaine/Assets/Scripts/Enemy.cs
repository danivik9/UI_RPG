using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float minDamage, maxDamage;
    private float startHealth;
    private float startMinDamage;
    private float startMaxDamage;


    public GameObject idlePanel;
    public GameObject shootingPanel;

    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, maxDamage);
        toHit.TakeDamage(damage);
        ShowShootingSprite();
    }

    public void ShowShootingSprite()
    {
        if (idlePanel != null && shootingPanel != null)
        {
            idlePanel.SetActive(false);
            shootingPanel.SetActive(true);
            Invoke("ShowIdleSprite", 0.5f);
        }
    }

    private void ShowIdleSprite()
    {
        if (idlePanel != null && shootingPanel != null)
        {
            idlePanel.SetActive(true);
            shootingPanel.SetActive(false);
        }
    }

    public void ResetForNextLevel(int level)
    {
        health = startHealth;
        minDamage = startMinDamage + (level * 1);
        maxDamage = startMaxDamage + (level * 2);
        Debug.Log("Enemy reset! Now deals " + minDamage + "-" + maxDamage + " damage!");
    }

    void Start()
    {
        startHealth = health;
        startMinDamage = minDamage;
        startMaxDamage = maxDamage;

      
        if (idlePanel != null) idlePanel.SetActive(true);
        if (shootingPanel != null) shootingPanel.SetActive(false);
    }
}