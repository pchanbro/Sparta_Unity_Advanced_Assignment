using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITouch : MonoBehaviour
{
    public void Touch()
    {
        GameManager.Instance.OnAttack();
    }
}
