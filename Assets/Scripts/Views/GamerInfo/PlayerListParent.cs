using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerListParent:MonoBehaviour
{
	public PlayerItem playerItem;

	private Vector3[] playerItemPos={
		new Vector3(-160,180,0),
		new Vector3(-160,106,0),
		new Vector3(-160,33,0),
		new Vector3(-160,-40,0),
		new Vector3(-160,-114,0),
	};

	public PlayerItem[] Init (int iStart,int iEnd){
		List<PlayerJson> playerjsons = new List<PlayerJson> ();
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==1 || json.PlayerCategory==2){
				playerjsons.Add (json);
			}
		}
		PlayerItem[] playeritems=new PlayerItem[iEnd-iStart+1];
		for(int i=0;i<iEnd-iStart+1;i++){
			playeritems[i]=(PlayerItem)GameObject.Instantiate (playerItem);
			playeritems[i].SetData (playerjsons[iStart+i]);
			NGUIUtility.SetParent (transform, playeritems[i].transform);
			playeritems[i].transform.localPosition = playerItemPos [i];
		}
		return playeritems;
	}

}

