using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

    private TeamDispatcher teamDispatcher;

	// Use this for initialization
	void Start () {
        teamDispatcher = new TeamDispatcher();

    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Team TeamOfNewPlayer = teamDispatcher.GetNextPlayerColor();
        Spawn spawnObject = FindSpawn(TeamOfNewPlayer);
        GameObject player = (GameObject)Instantiate(playerPrefab, spawnObject.transform.position, spawnObject.transform.rotation);
        player.GetComponent<TeamManager>().AssignTeam(TeamOfNewPlayer);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

    }

    private Spawn FindSpawn(Team teamToSpawn)
    {

        List<Spawn> spawn = new List<Spawn>(FindObjectsOfType<Spawn>());
        return spawn.FindAll(
            delegate(Spawn spawnToFilter)
            {
            return spawnToFilter.GetAssignTeam() == teamToSpawn;
            })[0];

    }
}
