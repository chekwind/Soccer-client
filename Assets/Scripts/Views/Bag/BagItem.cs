using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagItem:MonoBehaviour{
	
	public UILabel labelNum;
	public UISprite spriteItem;
	
	private ItemJson itemjson;
	
	public void SetData(ItemJson json){
		if (json == null) {
			labelNum.gameObject.SetActive(false);
			spriteItem.gameObject.SetActive(false);
		} else {
			itemjson = json;
			labelNum.text=json.stack.ToString();
			spriteItem.spriteName=json.Icon;
		}
	}
	public int GetItemId(){
		if(itemjson!=null){
			return itemjson.itemid;
		}else{
			return 0;
		}
	}
	public void onClick(){
		Globals.It.SetBagRight (itemjson);
	}
}