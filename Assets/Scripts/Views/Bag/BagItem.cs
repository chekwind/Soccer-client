using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagItem:MonoBehaviour{
	
	public UILabel labelNum;
	public UISprite spriteItem;
	
	private ItemJson itemjson;
	
	public void SetData(ItemJson json){
		if (json == null) {
			labelNum.enabled=false;
			spriteItem.enabled=false;
		} else {
			labelNum.text=json.stack.ToString();
			spriteItem.spriteName=json.Icon;
		}
	}
	public void onClick(){
//		if (itemjson != null) {
//			
//		}
	}
}