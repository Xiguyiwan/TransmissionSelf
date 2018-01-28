using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ClickNavigation : Interaction {
    public float RelaxDistance = 5;
    private NavMeshAgent agent;
    private Vector3 target = Vector3.zero;//目的地位置
    private bool selected = false;//当玩家点击右键事是否要执行选中操作
    private bool isActive = false;//NavMesh是否启用并控制单位移动
    
    public override void Deselect()
    {
        selected = false;
    }
    public override void Select()
    {
        selected = true;
    }
    public void SendToTarget()
    {
        agent.SetDestination(target);
        agent.Resume();//代理恢复
        isActive = true;
    }
    public void SendToTarget(Vector3 pos)
    {
        target = pos;
        SendToTarget();
    }
    void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (selected && Input.GetMouseButtonDown(1))
        {
            var tempTarget = GameManager.Current.ScreenPointToMapPosition(Input.mousePosition);
            if (tempTarget.HasValue)
            {
                target = tempTarget.Value;
                SendToTarget();
            }
        }
        if (isActive && Vector3.Distance (target,transform.position)<RelaxDistance)
        {
            agent.Stop();
            isActive = false;
        }
	}
}
