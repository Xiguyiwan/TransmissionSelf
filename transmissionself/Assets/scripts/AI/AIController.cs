using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    public float Confusion = 0.3f;//添加在AI权重上的随机值
    public float Frequenct = 1; //我们检测的频率

    private float waited = 0; //两次决策间隔时间的花费

    public string PlayerName; //所属玩家的名字
    private PlayerSetupDefinition playerN;//所属玩家的详细信息
    public PlayerSetupDefinition PlayerN { get { return playerN; } set { playerN = value; } }
    // Use this for initialization
    void Start () {
        
       
        foreach (var p in GameManager.Current.Players)
        {
            if (p.Name == PlayerName)
            {
                playerN = p;
            }
            
            Debug.Log(p.Name);
        }
        Debug.Log(PlayerN.Name);
        
    }
	
	// Update is called once per frame
	void Update () {
       
        waited += Time.deltaTime;
        if (waited < Frequenct)//间隔时间判断
        {
            return;
        }
    
        waited = 0;
	}
}
