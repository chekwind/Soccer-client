using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class BuyView:MonoBehaviour{

	public UILabel labelName, labelCost, labelDes, labelTotal,labelNum;
	public UISprite spriteIcon;
	private int cost;
	private ItemJson itemjson;

	public void show(ItemJson json){
		itemjson = json;
		labelName.text = json.ItemName.ToString();
		labelCost.text = json.cost.ToString ();
		labelDes.text = json.Description.ToString ();
		spriteIcon.spriteName = json.Icon.ToString ();
		labelNum.text = "1";
		cost = json.cost;
		labelTotal.text = (Convert.ToInt32 (labelNum.text) * json.cost).ToString () + "金币";
	}
	public void onAdd(){
		labelNum.text = (Convert.ToInt32 (labelNum.text) + 1).ToString ();
		labelTotal.text = (Convert.ToInt32 (labelNum.text) * cost).ToString () + "金币";
	}
	public void onPlus(){
		int num = Convert.ToInt32 (labelNum.text);
		if(num>1){
			num--;
			labelNum.text = num.ToString ();
			labelTotal.text = (num * cost).ToString () + "金币";
		}
	}
	public void onBuy(){
		Data_BuyItem data = new Data_BuyItem (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
			shopCategory=1,
			itemId=itemjson.itemid,
			buyNum=Convert.ToInt32 (labelNum.text),
		};
		Globals.It.SendMsg (data, Const_ICommand.BuyItem);
	}
	public void onClose(){
		Globals.It.DestoryBuyView ();
	}

}

