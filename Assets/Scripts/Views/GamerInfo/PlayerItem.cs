using UnityEngine;
using System.Collections;

public class PlayerItem:MonoBehaviour{

	public UILabel labelName,labelPower,labelWeizhi,labelLevel;
	public UISprite spriteCol,spriteHead;

	private PlayerJson playerjosn;

	public void SetData(PlayerJson json){

		playerjosn = json;

		labelName.text = json.PlayerName.ToString();
		labelPower.text = json.PlayerPower.ToString();
		labelLevel.text = "Lv "+json.Level.ToString ();

		switch(json.Role){
		case 1:labelWeizhi.text="门将";break;
		case 2:labelWeizhi.text="后卫";break;
		case 3:labelWeizhi.text="中场";break;
		case 4:labelWeizhi.text="前锋";break;
		default:break;
		}

		switch(json.PlayerQuality){
		case 1:spriteCol.spriteName="Public_Player01";break;
		case 2:spriteCol.spriteName="Public_Player02";break;
		case 3:spriteCol.spriteName="Public_Player03";break;
		case 4:spriteCol.spriteName="Public_Player04";break;
		case 5:spriteCol.spriteName="Public_Player05";break;
		case 6:spriteCol.spriteName="Public_Player06";break;
		default:break;
		}
	}

	public void onClick(){
		Globals.It.ShowPlayerInfo (playerjosn,1);
	}


}