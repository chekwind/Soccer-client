using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BagView:MonoBehaviour{

	public UIGrid gridBagItemParent;
	public GameObject gridChildItem;
	public UIPanel itemPanel;
	public UISprite spritebtn1, spritebtn2, spritebtn3,spriteitem;
	public UIImageButton btncompose,btnuse;
	public UILabel labelItemname;
	private int ItemPage=1;
	private BagParent itemParent;
	private List<BagItem> m_Items = new List<BagItem> ();
	private ItemJson itemjson;

	public void show(){

		spriteitem.gameObject.SetActive(false);
		btncompose.gameObject.SetActive (false);
		btnuse.gameObject.SetActive (false);
		labelItemname.gameObject.SetActive (false);
		GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
		itemParent = gridItem.GetComponent<BagParent> ();
		switch(ItemPage){
		case 1:spritebtn1.spriteName="btnsilver1_down";spritebtn2.spriteName="btnsilver2";spritebtn3.spriteName="btnsilver3";break;
		case 2:spritebtn1.spriteName="btnsilver1";spritebtn2.spriteName="btnsilver2_down";spritebtn3.spriteName="btnsilver3";break;
		case 3:spritebtn1.spriteName="btnsilver1";spritebtn2.spriteName="btnsilver2";spritebtn3.spriteName="btnsilver3_down";break;
		default:break;
		}
		m_Items.AddRange (itemParent.Init(ItemPage));
		NGUIUtility.SetParent (gridBagItemParent.transform, gridItem.transform);
	}
	public void onUse(){
		if (itemjson != null) {
			Data_UseItem data = new Data_UseItem (){
				characterId=Globals.It.MainGamer.proMain.iCharacterId,
				itemId=itemjson.itemid,
				targetId=0,
			};
			Globals.It.SendMsg (data, Const_ICommand.UseItem);
			for (int i=0; i<m_Items.Count; i++) {
				if(m_Items[i].GetItemId()==itemjson.itemid){
					itemjson.stack-=1;
					if(itemjson.stack<=0){
						refresh();
					}else{
						m_Items[i].SetData(itemjson);
					}
				}
			}
		}

	}
	public void onChangeType(GameObject sprite){
		switch(sprite.name){
		case "Spritebtn1":ItemPage=1;break;
		case "Spritebtn2":ItemPage=2;break;
		case "Spritebtn3":ItemPage=3;break;
		default:break;
		}
		GameObject.DestroyImmediate(itemParent.gameObject,true);
		show ();
	}
	public void SetBagRight(ItemJson json){
		itemjson = json;
		spriteitem.gameObject.SetActive(true);
		labelItemname.gameObject.SetActive (true);
		if (json.UseType == 1) {
			btnuse.gameObject.SetActive(true);
		}else {
			btncompose.gameObject.SetActive (true);	
		}
		labelItemname.text = json.ItemName.ToString ();
		spriteitem.spriteName = json.Icon;
	}
	public void refresh(){
		Data_BagInfo data = new Data_BagInfo (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
		};
		Globals.It.SendMsg (data, Const_ICommand.BagInfo);
	}
	public void reshow(){
		Globals.It.DestoryBagView ();
		Globals.It.ShowBagView ();
	}
	public void onClose(){
		Globals.It.DestoryBagView ();
	}
}

