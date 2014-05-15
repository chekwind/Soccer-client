using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InnerParent:MonoBehaviour
{
	public InnerPlayer innerplayer;
	
	private Vector3[] playerPos={
		new Vector3(-350,0,0),
		new Vector3(-250,0,0),
		new Vector3(-150,0,0),
		new Vector3(-50,0,0),
		new Vector3(50,0,0),
		new Vector3(150,0,0),
		new Vector3(250,0,0),
		new Vector3(350,0,0),
	};
	
	public InnerPlayer[] Init (){
		List<PlayerJson> playerjsons = new List<PlayerJson> ();
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==3){
				playerjsons.Add (json);
			}
		}
		InnerPlayer[] innerplayers=new InnerPlayer[8];
		for(int i=0;i<8;i++){
			innerplayers[i]=(InnerPlayer)GameObject.Instantiate (innerplayer);
			PlayerJson data=null;
			if(i<playerjsons.Count){
				data=playerjsons[i];
			}
			innerplayers[i].SetData (data);
			NGUIUtility.SetParent (transform, innerplayers[i].transform);
			innerplayers[i].transform.localPosition = playerPos [i];
		}
		return innerplayers;
	}
}

