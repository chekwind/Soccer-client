using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RotateView:MonoBehaviour{
	
	public UILabel labelPower;
	public UIGrid gridLineUpParent,gridBenchParent;
	public GameObject gridChildItem,gridChildItem2;
	public UIPanel playerPanel,benchPanel;

	private List<Player> m_Players = new List<Player> ();

	public void show(){
		GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
		LineUpParent itemParent = gridItem.GetComponent<LineUpParent> ();
		m_Players.AddRange (itemParent.Init ());
		NGUIUtility.SetParent (gridLineUpParent.transform, gridItem.transform);
		gridLineUpParent.Reposition ();

		GameObject gridItem2 = (GameObject)GameObject.Instantiate (gridChildItem2);
		BenchParent itemParent2 = gridItem2.GetComponent<BenchParent> ();
		m_Players.AddRange (itemParent2.Init ());
		NGUIUtility.SetParent (gridBenchParent.transform, gridItem2.transform);
		gridBenchParent.Reposition ();
		
		labelPower.text = "球队实力："+Globals.It.MainGamer.proMain.iPower.ToString ();
	}
	
	public void onClose(){
		Globals.It.DestoryRotateView ();
		Globals.It.ShowLineUp ();
		Globals.It.MainGamer.proMain.rotateplayer.Clear ();
	}
	public void Rotate(int mainplayer,int benchplayer){
			Data_PlayerRotate data = new Data_PlayerRotate (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
			mainPlayerId=mainplayer,
			benchPlayerId=benchplayer
		};
		Globals.It.SendMsg (data, Const_ICommand.PlayerRotate);
		Globals.It.ShowWaiting ();
	}
	public void Refresh(){
		Globals.It.DestoryRotateView ();
		Globals.It.ShowRotateView ();
	}
}

