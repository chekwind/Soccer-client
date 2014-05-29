using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameCenterView:MonoBehaviour{

	public UISprite spritelock;
	public UILabel labeltext4;
	public UIImageButton btn4;
	
	public void show(){
		labeltext4.gameObject.SetActive (false);
		spritelock.gameObject.SetActive (false);
		if (Globals.It.MainGamer.proMain.iLevel < 30) {
			btn4.isEnabled=false;
			labeltext4.gameObject.SetActive (true);
			spritelock.gameObject.SetActive (true);
		}
	}
	public void onClick(GameObject btn){
		switch (btn.name) {
		case "Btn1":
			Debug.Log ("1");
			break;
		case "Btn2":
			int Leagueindex=2;
			int level=Globals.It.MainGamer.proMain.iLevel;
			if(level>20&&level<=30){Leagueindex=2;}
			if(level>30&&level<=40){Leagueindex=3;}
			if(level>40&&level<=50){Leagueindex=4;}
			if(level>50&&level<=60){Leagueindex=5;}
			Data_GetTrainMatch data = new Data_GetTrainMatch (){
				characterId=Globals.It.MainGamer.proMain.iCharacterId,
				leagueindex=Leagueindex,
			};
			Globals.It.SendMsg (data, Const_ICommand.GetTrainMatch);
			break;
		case "Btn3":
			Debug.Log ("3");
			break;
		case "Btn4":
			Debug.Log ("4");
			break;
		}
	}
	public void onClose(){
		Globals.It.DestoryGameCenter();
	}
	
}

