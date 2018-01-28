using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GameManager : MonoBehaviour {
    public static GameManager Current;
    // Use this for initialization
    public List<PlayerSetupDefinition> Players = new List<PlayerSetupDefinition>();

    public TerrainCollider MapCollider;
    void Start () {
        Current = this;
        foreach (var p in Players)
        {
            
            foreach (var u in p.StartingUnits)
            {
                var go = (GameObject)GameObject.Instantiate(u, p.Location.position, p.Location.rotation);
                var player = go.AddComponent<Player>();
                player.Info = p;
                p.ActiveUnits.Add(u);
                if (!p.IsAi)
                {
                    if (Player.Default == null)
                    {
                        Player.Default = p;
                    }
                    go.AddComponent<NavMeshAgent>();
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector3? ScreenPointToMapPosition(Vector2 point)
    {
        var ray = Camera.main.ScreenPointToRay(point);
        RaycastHit hit;
        if (!MapCollider.Raycast(ray,out hit,Mathf.Infinity))
        {
            return null;
        }
        return hit.point;
    }
}
