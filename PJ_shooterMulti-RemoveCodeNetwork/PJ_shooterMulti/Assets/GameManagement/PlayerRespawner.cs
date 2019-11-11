using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerRespawner : NetworkBehaviour {
    public float respawnTime = 2;

    [Command]

    public void CmdRespawn(GameObject player)
    {

    }

  

    IEnumerable Respawn(GameObject player, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Spawn spawnObject = FindSpawn(player.GetComponent<TeamManager>().GetTeam());
        player.GetComponent<PlayerController>().RpcRevive(spawnObject.gameObject);
    }



    private Spawn FindSpawn(Team teamToSpawn) {
        List<Spawn> spawns = new List<Spawn>(FindObjectsOfType<Spawn>());
        return spawns.FindAll(
            delegate (Spawn spawnToFilter) {
                return spawnToFilter.GetAssignTeam() == teamToSpawn;
            }
            )[0];
    }
}
