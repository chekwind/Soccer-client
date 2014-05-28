using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TrainMatchView:MonoBehaviour{
	
	public UIGrid gridParent;
	public GameObject gridChildItem;
	public UIPanel trainmatchPanel;

	private List<TrainMatchNPC> m_npcs = new List<TrainMatchNPC> ();
	public void show(Data_GetTrainMatch_R.Data npcs){

		int iCount = npcs.NPC.Length / 8;

		Globe.listcount = iCount-1;
		Globe.offset = 960;
		Globe.currentindex = 0;

		List<Data_GetTrainMatch_R.NPC> npclist = new List<Data_GetTrainMatch_R.NPC> ();
		for (int i=1; i<=iCount; i++) {
			npclist.Clear();
			foreach (Data_GetTrainMatch_R.NPC npcdata in npcs.NPC) {
				if(npcdata.LeagueIndex==i){
					npclist.Add(npcdata);
				}
			}
			GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
			TrainMatchParent itemParent = gridItem.GetComponent<TrainMatchParent> ();
			m_npcs.AddRange (itemParent.Init (npclist));
			NGUIUtility.SetParent (gridParent.transform, gridItem.transform);
		}
		gridParent.Reposition ();
	}
	public void onClose(){
		Globals.It.DestoryTrainMatchView();
	}
	
}

