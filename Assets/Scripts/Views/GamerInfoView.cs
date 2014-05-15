using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GamerInfoView:MonoBehaviour{

	public UILabel labelName,labelLevel,labelPower,labelRepute,LabelZen;
	public UIGrid gridPlayerItemParent;
	public GameObject gridChildItem;
	public UIPanel playerPanel;

	private List<PlayerItem> m_PlayerItems = new List<PlayerItem> ();

	public void show(){
			
		int iPlayerCount = 0;
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==1 || json.PlayerCategory==2){
				iPlayerCount++;
			}
		}
		int iObjectCount = iPlayerCount / 5;
		int iend = iPlayerCount % 5;
		if (iend != 0) {
			iObjectCount+=1;
		}
		int iPos = 0, iOffset = 0;
		for (; iPos<iObjectCount; iPos++) {
			GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
			PlayerListParent itemParent = gridItem.GetComponent<PlayerListParent> ();
			if(iPos==0){
				m_PlayerItems.AddRange (itemParent.Init (0,4));
				iOffset=5;
			}
			else if(iPlayerCount>=(iPos+1)*5){
				m_PlayerItems.AddRange (itemParent.Init (iOffset,iOffset+4));
				iOffset+=5;
			}else{
				m_PlayerItems.AddRange (itemParent.Init (iOffset,iOffset+iend-1));
			}
			NGUIUtility.SetParent (gridPlayerItemParent.transform, gridItem.transform);
		}
		gridPlayerItemParent.Reposition ();

		labelName.text = Globals.It.MainGamer.proMain.sRoleName.ToString();
		labelLevel.text = Globals.It.MainGamer.proMain.iLevel.ToString();
		labelPower.text=Globals.It.MainGamer.proMain.iPower.ToString();
		labelRepute.text=Globals.It.MainGamer.proMain.iRepute.ToString();
		switch(Globals.It.MainGamer.proMain.iZenID){
		case 1:LabelZen.text="初级进攻";break;
		case 2:LabelZen.text="高级进攻";break;
		case 3:LabelZen.text="初级组织";break;
		case 4:LabelZen.text="高级组织";break;
		case 5:LabelZen.text="初级防守";break;
		case 6:LabelZen.text="高级防守";break;
		default:break;
		}
	}

	public void onClose(){
		Globals.It.DestoryGamerInfoView ();
	}

	public void onClick(){
//		Debug.Log ("OnClick");
	}

}