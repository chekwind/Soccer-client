using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TrainParent:MonoBehaviour
{
	public PlayerTrain playertrain;
	
	private Vector3[] playerPos={
		new Vector3(0,160,0),
		new Vector3(0,50,0),
		new Vector3(0,-60,0),
		new Vector3(0,-170,0),
	};
	
	public PlayerTrain[] Init (int iStart,int iEnd){
		List<PlayerJson> playerjsons = new List<PlayerJson> ();
		List<PlayerJson> benchjsons = new List<PlayerJson> ();
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==1){
				playerjsons.Add (json);
			}else if(json.PlayerCategory==2){
				benchjsons.Add(json);
			}
		}
		foreach(PlayerJson json in benchjsons){
			playerjsons.Add(json);
		}
		Globals.It.MainGamer.proMain.playertemp = playerjsons [playerjsons.Count - 1];
		PlayerTrain[] playertrains=new PlayerTrain[iEnd-iStart+1];
		for(int i=0;i<iEnd-iStart+1;i++){
			playertrains[i]=(PlayerTrain)GameObject.Instantiate (playertrain);
			playertrains[i].SetData (playerjsons[iStart+i]);
			NGUIUtility.SetParent (transform, playertrains[i].transform);
			playertrains[i].transform.localPosition = playerPos [i];
		}
		return playertrains;
	}
}

