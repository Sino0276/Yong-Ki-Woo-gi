using System;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image bossHealthBar;
    [SerializeField] private Image TimerBar;

    private StageManager stageManager;
    private float maxHealth;

    public void Start()
    {
        stageManager = GameManager.Instance.StageManager;
    }

    public void Update()
    {
        TimerBar.fillAmount = 1 - (stageManager.currentTime / stageManager.bossTimeLimit);
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void SetBossUI(EnemyController enemy)
    {
        maxHealth = enemy.Health;
        bossHealthBar.fillAmount = 1;
        Show();
        enemy.OnHealthChange += OnHealthChange;
        enemy.OnDeath += OnDeath;
    }

    private void OnDeath(bool obj)
    {
        Hide();
    }

    private void OnHealthChange(float health)
    {
        bossHealthBar.fillAmount = health / maxHealth;
    }
}
