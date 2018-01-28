using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using DG.Tweening;
using UnityEngine.AI;
public class Believers : MonoBehaviour {
    [SerializeField]
    private float Scale;
    [SerializeField]
    private float WalkSpeed;
    public string Faith;
    [SerializeField]
    private float Communication;
    [SerializeField]
    private float HP;
    public float CurrentHP;
    // Use this for initialization
    [SerializeField]
    private Vector3 SliderScaleValue = new Vector3(1,1,1);
    [SerializeField]
    private Color32 colorself;
    private Color32 newColor;

    public float FindTargetDelay = 1;  // 寻找目标间隔  
    public float FindRange = 40;
    public float AttackRange = 5;     //攻击范围  
    public float AttackFrequency = 0.25f;  //攻击频率  
    public float AttackDamage = 1;      //伤害值
    private bool OnTheWay = false;
    private bool NoWay = false;
    private PlayerSetupDefinition player;   //玩家的所属阵营  
    private float findTargetCounter = 0;   //计时器
    private float attackCounter = 0;

    private Believers info;
    AiSupport ai;

    private NavMeshAgent agent;
    public Vector3 ForceOnPos;
    private void Awake()
    {
        Scale = 0.2f * (int)(Random.Range(1, 10));
        //Debug.Log(Scale + "this is scale");
        WalkSpeed = 2.5f-Scale;
        Communication = 10 + Scale * 2;
        Faith = null;
        CurrentHP = HP = 500 + Scale * 200;
        //Debug.Log("scale:" + Scale + " walkspeed:" + WalkSpeed + " communication:" + Communication + " faith:" + Faith + " HP:" + HP);

        agent = GetComponent<NavMeshAgent>();
    }
    void Start () {
        SliderScaleValue *= Scale;
        this.transform.localScale = SliderScaleValue;

        player = GetComponent<Player>().Info;//获取所属玩家信息

        ai = AiSupport.GetSupport(this.gameObject);
        info = GetComponent<Believers>();
        
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.Translate(Vector3.right * WalkSpeed * Time.deltaTime);
        findTargetCounter += Time.deltaTime;
        if (findTargetCounter > FindTargetDelay && !OnTheWay)   //寻找目标  
        {
            ForceOnPos = FindTarget();
            findTargetCounter = 0;
        }
       
       
        attackCounter += Time.deltaTime;
        if (attackCounter > AttackFrequency)   //攻击  
        {
            Attack();
            attackCounter = 0;
        }
    }
    public void Missionary(float Effect,GameObject enemy)
    {
        CurrentHP -= Effect;
        if (CurrentHP <= 0)
        {
            
        }
    }
    IEnumerator ChangeColor() {
        float different = CurrentHP / HP;
        
        float newR = 0;
        float newG = 0;
        float newB = 0;
        float R = this.gameObject.GetComponent<MeshRenderer>().material.color.r;
        float G = this.gameObject.GetComponent<MeshRenderer>().material.color.g;
        float B = this.gameObject.GetComponent<MeshRenderer>().material.color.b;
        newR = (newColor.r / 255) * different;
        //Debug.Log(newR + "this is newR");
        newG = (newColor.g /255)* different;
        newB = (newColor.b /255)* different;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(newR, newG, newB);
        yield return null; 
    }
    /// <summary>  
    /// 寻找目标  
    /// </summary>  
    Vector3 FindTarget()
    {
        

        foreach (var p in GameManager.Current.Players)
        {
            if (p == player)
                continue;
            if (p.ActiveUnits.Count < 5) //活跃信徒少于5则不攻击玩家
                continue;

            foreach (var unit in p.ActiveUnits)
            {
                if (DefferentWithSelf(unit.transform.position, transform.position) < FindRange)
                {
      

                }
            }
        }
   
        return (new Vector3(0, 0, 0));
    }
    void Attack()
    {
    }
    float DefferentWithSelf(Vector3 my,Vector3 tar)
    {
        return Vector3.Distance(my, tar);
    }
}
