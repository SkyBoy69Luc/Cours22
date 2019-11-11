using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRespawner : MonoBehaviour {
    public float respawnTime = 2;

    private Spawn FindSpawn(Team teamToSpawn) {
        List<Spawn> spawns = new List<Spawn>(FindObjectsOfType<Spawn>());
        return spawns.FindAll(
            delegate (Spawn spawnToFilter) {
                return spawnToFilter.GetAssignTeam() == teamToSpawn;
            }
            )[0];
    }
}
