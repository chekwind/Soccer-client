using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StoreParent:MonoBehaviour
{
	public StoreItem item;
	
	private Vector3[] itemPos={
		new Vector3(-180,120,0),new Vector3(190,120,0),new Vector3(-180,0,0),new Vector3(190,0,0),new Vector3(-180,-120,0),new Vector3(190,-120,0),
	};
	
	public StoreItem[] Init (int iStart,int iEnd){
		List<ItemJson> itemjsons = new List<ItemJson> ();
		foreach (ItemJson json in Globals.It.MainGamer.proMain.lStoreItemList) {
//			if(json.ItemPage==itempage){
				itemjsons.Add (json);
//			}
		}
		StoreItem[] items=new StoreItem[iEnd-iStart+1];
		for(int i=0;i<iEnd-iStart+1;i++){
			items[i]=(StoreItem)GameObject.Instantiate (item);
			items[i].SetData (itemjsons[iStart+i]);
			NGUIUtility.SetParent (transform, items[i].transform);
			items[i].transform.localPosition = itemPos [i];
		}
		return items;
	}
}

