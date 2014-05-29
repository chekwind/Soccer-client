using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TrainMatchParent:MonoBehaviour
{
	public TrainMatchNPC npc;
	
	private Vector3[] playerPos={
		new Vector3(-240,60,0),
		new Vector3(-80,60,0),
		new Vector3(80,60,0),
		new Vector3(240,60,0),
		new Vector3(-240,-100,0),
		new Vector3(-80,-100,0),
		new Vector3(80,-100,0),
		new Vector3(240,-100,0),
	};
	public TrainMatchNPC[] Init (List<Data_GetTrainMatch_R.NPC> npclist){
		TrainMatchNPC[] npcs=new TrainMatchNPC[8];
		for(int i=0;i<8;i++){
			npcs[i]=(TrainMatchNPC)GameObject.Instantiate (npc);
			npcs[i].SetData (npclist[i]);
			NGUIUtility.SetParent (transform, npcs[i].transform);
			npcs[i].transform.localPosition = playerPos [i];
		}
		return npcs;
	}
}

