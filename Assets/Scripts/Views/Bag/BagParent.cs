using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BagParent:MonoBehaviour
{
	public BagItem item;
	
	private Vector3[] itemPos={
		new Vector3(-250,140,0),new Vector3(-150,140,0),new Vector3(-50,140,0),new Vector3(50,140,0),new Vector3(150,140,0),new Vector3(250,140,0),
		new Vector3(-250,45,0),new Vector3(-150,45,0),new Vector3(-50,45,0),new Vector3(50,45,0),new Vector3(150,45,0),new Vector3(250,45,0),
		new Vector3(-250,-50,0),new Vector3(-150,-50,0),new Vector3(-50,-50,0),new Vector3(50,-50,0),new Vector3(150,-50,0),new Vector3(250,-50,0),
		new Vector3(-250,-145,0),new Vector3(-150,-145,0),new Vector3(-50,-145,0),new Vector3(50,-145,0),new Vector3(150,-145,0),new Vector3(250,-145,0),
	};
	
	public BagItem[] Init (int itempage){
		List<ItemJson> itemjsons = new List<ItemJson> ();
		foreach (ItemJson json in Globals.It.MainGamer.proMain.lBagItemList) {
			if(json.ItemPage==itempage){
				itemjsons.Add (json);
			}
		}
		BagItem[] items=new BagItem[24];
		for(int i=0;i<24;i++){
			items[i]=(BagItem)GameObject.Instantiate (item);
			ItemJson data=null;
			if(i<itemjsons.Count){
				data=itemjsons[i];
			}
			items[i].SetData (data);
			NGUIUtility.SetParent (transform, items[i].transform);
			items[i].transform.localPosition = itemPos [i];
		}
		return items;
	}
}

