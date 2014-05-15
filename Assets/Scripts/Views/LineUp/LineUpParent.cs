using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LineUpParent:MonoBehaviour
{
	public Player player;
	
	private Vector3[] playerPos={
		new Vector3(-100,-170,0),
		new Vector3(-320,-90,0),
		new Vector3(-180,-90,0),
		new Vector3(-40,-90,0),
		new Vector3(100,-90,0),
		new Vector3(-240,30,0),
		new Vector3(-100,-10,0),
		new Vector3(-100,80,0),
		new Vector3(40,30,0),
		new Vector3(-200,160,0),
		new Vector3(0,160,0),
	};
	
	public Player[] Init (){
		List<PlayerJson> playerlist = new List<PlayerJson> ();
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==1){
				playerlist.Add (json);
			}
		}
		Player[] players=new Player[11];
		for(int i=0;i<11;i++){
			players[i]=(Player)GameObject.Instantiate (player);
			players[i].SetData (playerlist [i]);
			NGUIUtility.SetParent (transform, players[i].transform);
			switch(playerlist[i].PlayerPos){
			case "a":players[i].transform.localPosition = playerPos [0];break;
			case "b":players[i].transform.localPosition = playerPos [1];break;
			case "c":players[i].transform.localPosition = playerPos [2];break;
			case "d":players[i].transform.localPosition = playerPos [3];break;
			case "e":players[i].transform.localPosition = playerPos [4];break;
			case "f":players[i].transform.localPosition = playerPos [5];break;
			case "g":players[i].transform.localPosition = playerPos [6];break;
			case "h":players[i].transform.localPosition = playerPos [7];break;
			case "i":players[i].transform.localPosition = playerPos [8];break;
			case "j":players[i].transform.localPosition = playerPos [9];break;
			case "k":players[i].transform.localPosition = playerPos [10];break;
			}

		}
		return players;
	}
}

