using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StoreView:MonoBehaviour{
	
	public UIGrid gridStoreItemParent;
	public GameObject gridChildItem;
	public UIPanel itemPanel;
	private StoreParent itemParent;
	private List<StoreItem> m_Items = new List<StoreItem> ();

	public UILabel labelcoin;
	
	public void show(Data_StoreInfo_R.Data data){

		labelcoin.text = Globals.It.MainGamer.proMain.iCoin.ToString();

		int itemCount = 0;
		foreach (Data_StoreInfo_R.items item in data.items) {
//			if(json.PlayerCategory==1 || json.PlayerCategory==2){
			itemCount++;
//			}
		}
		int iObjectCount = itemCount / 6;
		int iend = itemCount % 6;
		if (iend != 0) {
			iObjectCount+=1;
		}
		int iPos = 0, iOffset = 0;
		for (; iPos<iObjectCount; iPos++) {
			GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
			itemParent = gridItem.GetComponent<StoreParent> ();
			if(iPos==0){
				if(itemCount<6){
					m_Items.AddRange (itemParent.Init (0,itemCount-1,data));
				}
				else{
					m_Items.AddRange (itemParent.Init (0,5,data));
					iOffset=6;
				}
			}
			else if(itemCount>=(iPos+1)*6){
				m_Items.AddRange (itemParent.Init (iOffset,iOffset+5,data));
				iOffset+=6;
			}else{
				m_Items.AddRange (itemParent.Init (iOffset,iOffset+iend-1,data));
			}
			NGUIUtility.SetParent (gridStoreItemParent.transform, gridItem.transform);
		}
		gridStoreItemParent.Reposition ();
	}
	public void onChangeType(GameObject sprite){
//		switch(sprite.name){
//		case "Spritebtn1":ItemPage=1;break;
//		case "Spritebtn2":ItemPage=2;break;
//		case "Spritebtn3":ItemPage=3;break;
//		default:break;
//		}
//		GameObject.DestroyImmediate(itemParent.gameObject,true);
//		show ();
	}
	public void Refresh(){
		labelcoin.text = Globals.It.MainGamer.proMain.iCoin.ToString();
	}
	public void onClose(){
		Globals.It.DestoryStoreView ();
	}
}

