using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BagView:MonoBehaviour{

	public UIGrid gridBagItemParent;
	public GameObject gridChildItem;
	public UIPanel itemPanel;
	public UISprite spritebtn1, spritebtn2, spritebtn3;
	private int ItemPage=1;
	private BagParent itemParent;
	private List<BagItem> m_Items = new List<BagItem> ();

	public void show(){

		GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
		itemParent = gridItem.GetComponent<BagParent> ();
		switch(ItemPage){
		case 1:spritebtn1.spriteName="bag_0011Down";spritebtn2.spriteName="bag_022";spritebtn3.spriteName="bag_033";break;
		case 2:spritebtn1.spriteName="bag_011";spritebtn2.spriteName="bag_0022Down";spritebtn3.spriteName="bag_033";break;
		case 3:spritebtn1.spriteName="bag_011";spritebtn2.spriteName="bag_022";spritebtn3.spriteName="bag_0033Down";break;
		default:break;
		}
		m_Items.AddRange (itemParent.Init(ItemPage));
		NGUIUtility.SetParent (gridBagItemParent.transform, gridItem.transform);
//		gridBagItemParent.Reposition ();
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
	public void onClose(){
		Globals.It.DestoryBagView ();
	}
}

