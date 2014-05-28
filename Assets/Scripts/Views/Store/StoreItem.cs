using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoreItem:MonoBehaviour{
	
	public UILabel labelName,labelCost;
	public UISprite spriteItem;

	Data_StoreInfo_R.items itemtemp=new Data_StoreInfo_R.items();
	
	public void SetData(Data_StoreInfo_R.items item){
		itemtemp = item;
		labelName.text=item.item.ItemName.ToString();
		labelCost.text = item.cost.ToString ();
		spriteItem.spriteName=item.item.Icon;
	}
	public void onBuy(){
		Globals.It.ShowBuyView (itemtemp);
	}



}