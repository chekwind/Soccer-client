using UnityEngine;
using System.Collections;

public class PlayerTrain:MonoBehaviour{
	
	public UILabel labelName,labelPower,labelWeizhi,labelLevel,labelCategory;
	public UISprite spriteCol,spriteHead,spriteBtnLvUp;
	public UISlider ExpSlider;
	
	private PlayerJson playerjson;
	
	public void SetData(PlayerJson json){
		
		playerjson = json;
		
		labelName.text = json.PlayerName.ToString();
		labelPower.text = json.PlayerPower.ToString();
		labelLevel.text = "Lv "+json.Level.ToString ();
		spriteHead.spriteName = json.Photo;
		spriteBtnLvUp.gameObject.SetActive(false);
		labelCategory.enabled = false;
		ExpSlider.sliderValue = json.Exp / json.MaxExp;
		if (ExpSlider.sliderValue == 1) {
			spriteBtnLvUp.gameObject.SetActive(true);
		}
		if (json.PlayerCategory == 2) {
			labelCategory.enabled = true;
		}
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
	
	public void onTraining(){
		Globals.It.ShowPlayerInfo (playerjson,2);
	}
	public void onLevelUp(){
		Data_PlayerUpdate data = new Data_PlayerUpdate (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
			playerid=playerjson.id,
			gamecoin=0,
			itemid=0,
		};
		Globals.It.SendMsg (data, Const_ICommand.PlayerUpdate);
	}
	
	
}