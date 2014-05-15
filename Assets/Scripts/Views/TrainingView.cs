using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TrainingView:MonoBehaviour{
	
	public UILabel labelTrainPoint;
	public UIGrid gridPlayerItemParent;
	public GameObject gridChildItem;
	public UIPanel playerPanel;
	private int iPlayerCount;


	private List<PlayerTrain> m_Players = new List<PlayerTrain> ();

	public void show(){

		iPlayerCount = 0;
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==1 || json.PlayerCategory==2){
				iPlayerCount++;
			}
		}
		int iObjectCount = iPlayerCount / 4;
		int iend = iPlayerCount % 4;
		if (iend != 0) {
			iObjectCount+=1;
		}
		int iPos = 0, iOffset = 0;
		for (; iPos<iObjectCount; iPos++) {
			GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
			TrainParent itemParent = gridItem.GetComponent<TrainParent> ();
			if(iPos==0){
				m_Players.AddRange (itemParent.Init (0,3));
				iOffset=4;
			}
			else if(iPlayerCount>=(iPos+1)*4){
				m_Players.AddRange (itemParent.Init (iOffset,iOffset+3));
				iOffset+=4;
			}else{
				m_Players.AddRange (itemParent.Init (iOffset,iOffset+iend-1));
			}
			NGUIUtility.SetParent (gridPlayerItemParent.transform, gridItem.transform);
		}
		gridPlayerItemParent.Reposition ();
		
		labelTrainPoint.text = "全队训练点："+Globals.It.MainGamer.proMain.iTrainPoint.ToString ();
	}
	
	public void onClose(){
		Globals.It.DestoryTrainingView ();
		Globals.It.ShowLineUp ();
	}
	public void Refresh(){
		labelTrainPoint.text = "全队训练点："+Globals.It.MainGamer.proMain.iTrainPoint.ToString ();
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
		if(m_Players.Count>playerjsons.Count){
			Globals.It.DestoryTrainingView();
			Globals.It.ShowTrainingView();
			Globals.It.DestoryPlayerView();
			Globals.It.ShowPlayerInfo(Globals.It.MainGamer.proMain.playertemp,2);
		}else{
		for (int i=0; i<iPlayerCount; i++) {
			m_Players[i].SetData(playerjsons[i]);
			}
		}
	}
}

