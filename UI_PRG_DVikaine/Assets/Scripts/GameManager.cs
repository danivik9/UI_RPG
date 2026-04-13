using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    
    [SerializeField] private TMP_Text playerName, playerHP, enemyName, playerWeapon, enemyHP;
    [SerializeField] private TMP_Text playerLevel;
    [SerializeField] private GameObject gameOverPanel;

    private bool gameOver = false;
    
    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.CharName;
        playerHP.text = "HP: " + player.health.ToString("F1");
        enemyHP.text = "HP: " + enemy.health.ToString("F1");
        playerWeapon.text = player.ActiveWeaponName;

        if (playerLevel != null)
        {
            playerLevel.text = "LVL: " + player.level;
        }
    }

    public void SwitchWeapon()
    {
        player.SwitchWeapons();
        UpdateUI();
    }

    public void AttackButton()
    {
        if (gameOver)
        {
            return;
        }

        player.Attack(enemy);

        if (enemy.IsDead())
        {
            player.level++;
            player.ResetHeal();
            enemy.ResetForNextLevel(player.level);
            
        }
        else
        {
            enemy.Attack(player);
        }

        if (player.IsDead())
        {
            gameOver = true;
           

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }

        UpdateUI();
    }

    public void HealButton()
    {
        if (gameOver)
        {
            return;
        }

        player.Heal();
        UpdateUI();
    }

    public void RestartGame()
    {
        gameOver = false;
        player.ResetPlayer();
        enemy.ResetForNextLevel(1);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        UpdateUI();
    }
}