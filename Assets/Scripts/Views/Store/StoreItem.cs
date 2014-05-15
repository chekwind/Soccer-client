using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoreItem:MonoBehaviour{
	
	public UILabel labelName,labelCost;
	public UISprite spriteItem;
	
	private ItemJson itemjson;

	
	public void SetData(ItemJson json){
		itemjson = json;
		labelName.text=json.ItemName.ToString();
		labelCost.text = json.cost.ToString ();
		spriteItem.spriteName=json.Icon;
	}
	public void onBuy(){
		Globals.It.ShowBuyView (itemjson);
	}



}