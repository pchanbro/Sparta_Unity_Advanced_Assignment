using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStat stat { get; private set; }
    private List<ItemData> itemDatas = new List<ItemData>();

    private void Awake()
    {
        stat = GetComponent<CharacterStat>();
    }
}
