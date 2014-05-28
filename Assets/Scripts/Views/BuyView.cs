using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class BuyView:MonoBehaviour{

	public UILabel labelName, labelCost, labelDes, labelTotal,labelNum;
	public UISprite spriteIcon;
	private int cost;
	Data_StoreInfo_R.items  itemtemp = new Data_StoreInfo_R.items ();

	public void show(Data_StoreInfo_R.items item){
		itemtemp = item;
		labelName.text = item.item.ItemName.ToString();
		labelCost.text = item.cost.ToString ();
		labelDes.text = item.item.Description.ToString ();
		spriteIcon.spriteName = item.item.Icon.ToString ();
		labelNum.text = "1";
		cost = item.cost;
		labelTotal.text = (Convert.ToInt32 (labelNum.text) * item.cost).ToString () + "金币";
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
			itemId=itemtemp.id,
			buyNum=Convert.ToInt32 (labelNum.text),
		};
		Globals.It.SendMsg (data, Const_ICommand.BuyItem);
	}
	public void onClose(){
		Globals.It.DestoryBuyView ();
	}

}

