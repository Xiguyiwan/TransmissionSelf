using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSetupDefinition{
    public string Name;//玩家名字
    public Transform Location;//起始位置
    public Color AccentColor;//玩家标识颜色
    public List<GameObject> StartingUnits = new List<GameObject>();
    public bool IsAi;//是不是AI控制
    public float Credits;//积分
    public List<GameObject> ActiveUnits = new List<GameObject>();
}
