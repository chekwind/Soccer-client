using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LineUpView:MonoBehaviour{

	public UILabel labelPower, labelTrainPoint,labelZen1,labelZen2;
	public UIGrid gridLineUpParent;
	public GameObject gridChildItem;
	public UIPanel playerPanel;
	
	private List<Player> m_Players = new List<Player> ();

	public void show(){
		GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
		LineUpParent itemParent = gridItem.GetComponent<LineUpParent> ();
		m_Players.AddRange (itemParent.Init ());
		NGUIUtility.SetParent (gridLineUpParent.transform, gridItem.transform);
		gridLineUpParent.Reposition ();

		labelPower.text = "球队实力："+Globals.It.MainGamer.proMain.iPower.ToString ();
		labelTrainPoint.text = "全队训练点："+Globals.It.MainGamer.proMain.iTrainPoint.ToString ();
		switch(Globals.It.MainGamer.proMain.iZenID){
		case 1:labelZen1.text="球队战术：初级进攻";labelZen2.text="球队阵型：4-3-3";break;
		case 2:labelZen1.text="球队战术：高级进攻";labelZen2.text="球队阵型：3-4-3";break;
		case 3:labelZen1.text="球队战术：初级组织";labelZen2.text="球队阵型：4-4-2";break;
		case 4:labelZen1.text="球队战术：高级组织";labelZen2.text="球队阵型：4-3-2-1";break;
		case 5:labelZen1.text="球队战术：初级防守";labelZen2.text="球队阵型：5-4-1";break;
		case 6:labelZen1.text="球队战术：高级防守";labelZen2.text="球队阵型：5-3-2";break;	
		}
	}

	public void onClose(){
		Globals.It.DestoryLineUpView ();
	}
	public void onRotate(){
		Globals.It.DestoryLineUpView ();
		Globals.It.ShowRotateView ();
	}
	public void onTrain(){
		Globals.It.DestoryLineUpView ();
		Globals.It.ShowTrainingView ();
	}
	public void onChangeTactics(){
		Globals.It.DestoryLineUpView ();
		Globals.It.ShowTacticsView ();
	}
}

