using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeadMgr : MonoBehaviour {
	
	public string headname;
    void Start () {
	UISprite UI = gameObject.GetComponent<UISprite>();
	if (UI == null) {
		return;
	} else {
		UI.spriteName =Globals.It.MainGamer.proMain.sPhoto;
	}

	}
}
