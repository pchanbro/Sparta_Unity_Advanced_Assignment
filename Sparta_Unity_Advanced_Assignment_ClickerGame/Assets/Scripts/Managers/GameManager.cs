using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static UIManager uiManager;

    public Character character;

    public event Action OnTouchEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(AutoAttack());
    }

    private IEnumerator AutoAttack()
    {
        while(true)
        {
            OnAttack();
            yield return new WaitForSeconds(1f);
        }
    }

    public void OnAttack()
    {
        Debug.Log("버튼누르면 공격");
        OnTouchEvent?.Invoke();
    }
}
