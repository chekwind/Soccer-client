using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BenchParent:MonoBehaviour
{
	public Player player;
	
	private Vector3[] playerPos={
		new Vector3(350,150,0),
		new Vector3(350,70,0),
		new Vector3(350,-10,0),
		new Vector3(350,-90,0),
		new Vector3(350,-170,0),
	};
	
	public Player[] Init (){
		List<PlayerJson> playerlist = new List<PlayerJson> ();
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==2){
				playerlist.Add (json);
			}
		}
		Player[] players=new Player[5];
		for(int i=0;i<5;i++){
			players[i]=(Player)GameObject.Instantiate (player);
			PlayerJson data=null;
			if(i<playerlist.Count){
				data=playerlist[i];
			}
			players[i].SetData (data);
			NGUIUtility.SetParent (transform, players[i].transform);
			players[i].transform.localPosition = playerPos [i];	
		}
		return players;
	}
}

