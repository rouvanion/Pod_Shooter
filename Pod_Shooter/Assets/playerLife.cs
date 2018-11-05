using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class playerLife : NetworkBehaviour {
    public RectTransform healthbar;
    public const int maxLife = 100;
    private NetworkStartPosition[] spawnpoint;

    [SyncVar(hook ="UpdateLife")]
    int currentlife = maxLife;
	// Use this for initialization
	void Start () {
		if(isLocalPlayer)
        {
            spawnpoint = FindObjectsOfType<NetworkStartPosition>();
        }
	}
	public void TakeDammage(int dammage)
    {
        if(isServer)
        {
            currentlife -= dammage;
            if(currentlife<=0)
            {
                currentlife = 0;
                Die();
            }
        }
    }
    private void UpdateLife(int newLife)
    {
        healthbar.sizeDelta = new Vector2(newLife, healthbar.sizeDelta.y);
    }
    private void Die()
    {
        RpcReSpawn();
    }
    void RpcReSpawn()
    {
        if(isLocalPlayer)
        {
            currentlife = maxLife;
            Vector3 spawnpoints = Vector3.zero;
            if(spawnpoint!=null&& spawnpoint.Length>0)
            {
                spawnpoints = spawnpoint[Random.Range(0, spawnpoint.Length)].transform.position;
            }
            transform.position = spawnpoints;
        }
    }
        // Update is called once per frame
	void Update () {
		
	}
}
