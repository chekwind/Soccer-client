using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerSignView:MonoBehaviour{

	public UILabel labelname, labelquality, labelrole, labelnation, labelheight, labelweight,labelpower;
	public UISprite spriteHeadCol;
	public UIImageButton btnsign, btndismiss;
	public UIPanel panelmask;

	private int playerid;

	public void show(Data_PickPlayer_R.player json,int source){
		panelmask.gameObject.SetActive (false);
		if (source == 1) {
			btnsign.gameObject.SetActive(false);
			btndismiss.gameObject.SetActive(false);
			panelmask.gameObject.SetActive (true);
		}
		playerid = json.id;
		labelname.text = json.PlayerName.ToString();
		labelpower.text ="能力"+ json.PlayerPower.ToString();
		labelnation.text = json.Nationality.ToString ();
		labelheight.text = json.Height.ToString () + "cm";
		labelweight.text = json.Weight.ToString () + "kg";

		switch(json.Role){
		case 1:labelrole.text="门将";;break;
		case 2:labelrole.text="后卫";break;
		case 3:labelrole.text="中场";break;
		case 4:labelrole.text="前锋";break;
		default:break;
		}
		
		switch(json.PlayerQuality){
		case 1:spriteHeadCol.spriteName="Player_player01";labelquality.text="一般";break;
		case 2:spriteHeadCol.spriteName="Player_player02";labelquality.text="优秀";break;
		case 3:spriteHeadCol.spriteName="Player_player03";labelquality.text="精英";break;
		case 4:spriteHeadCol.spriteName="Player_player04";labelquality.text="杰出";break;
		case 5:spriteHeadCol.spriteName="Player_player05";labelquality.text="大牌";break;
		case 6:spriteHeadCol.spriteName="Player_player06";labelquality.text="巨星";break;
		default:break;
		}
	}
	
	public void onClose(){
		Globals.It.DestoryPlayerSignView ();
	}
	public void onDismiss(){
		Data_DismissPlayer data = new Data_DismissPlayer (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
			playerId=playerid,
		};
		Globals.It.SendMsg (data, Const_ICommand.DismissPlayer);
	}
	public void onSign(){
		Data_SignPlayer data = new Data_SignPlayer (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
			playerId=playerid,
			gamecoin=1000,
		};
		Globals.It.SendMsg (data, Const_ICommand.SignPlayer);
	}
}

