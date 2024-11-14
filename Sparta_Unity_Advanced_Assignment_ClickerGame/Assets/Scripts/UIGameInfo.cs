using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameInfo : MonoBehaviour
{
    private CharacterStat characterStat;

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
        characterStat = GameManager.Instance.character.stat;

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

    private void GetGold()
    {
        gold.curValue = Mathf.Min(gold.curValue + characterStat.getGoldAmount, gold.maxValue);
    }

    private void GetScore()
    {
        score.curValue = Mathf.Min(score.curValue + characterStat.getScoreAmount, score.maxValue);
    }

    private void OnDamage()
    {
        enemyHP.curValue = Mathf.Max(enemyHP.curValue - characterStat.damage, enemyHP.minValue);
    }
}
