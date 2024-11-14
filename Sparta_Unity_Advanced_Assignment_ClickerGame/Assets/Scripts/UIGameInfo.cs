using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameInfo : MonoBehaviour
{
    [SerializeField]
    private GameInfo enemyHP;
    public GameInfo EnemyHP
    {
        get { return enemyHP; }
        set { enemyHP = value; }
    }

    [SerializeField]
    private GameInfo score;
    public GameInfo Score
    {
        get { return score; }
        set { score = value; }
    }

    [SerializeField]
    private GameInfo gold;
    public GameInfo Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    [SerializeField] private Image enemyHpbar;
    [SerializeField] private TMP_Text scoreValue;
    [SerializeField] private TMP_Text goldValue;

    private void Start()
    {
        GameManager.Instance.OnTouchEvent += GetGold;
        GameManager.Instance.OnTouchEvent += GetScore;
        GameManager.Instance.OnTouchEvent += OnDamage;
    }

    private void Update()
    {
        enemyHpbar.fillAmount = (float)enemyHP.curValue / enemyHP.maxValue;
        scoreValue.text = score.curValue.ToString();
        goldValue.text = gold.curValue.ToString();
    }

    private void GetGold(int amount)
    {
        gold.curValue = Mathf.Min(gold.curValue + amount, gold.maxValue);
    }

    private void GetScore(int amount)
    {
        score.curValue = Mathf.Min(score.curValue + amount, score.maxValue);
    }

    private void OnDamage(int amount)
    {
        enemyHP.curValue = Mathf.Max(enemyHP.curValue - amount, enemyHP.minValue);
    }
}
