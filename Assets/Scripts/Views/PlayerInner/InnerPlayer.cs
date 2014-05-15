using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InnerPlayer:MonoBehaviour{
	
	public UILabel labelName;
	public UISprite spriteCol,spriteHead;

	private PlayerJson playerjson;
	
	public void SetData(PlayerJson json){
		if (json == null) {
			labelName.enabled=false;

			spriteHead.enabled=false;
			spriteCol.enabled=false;
			spriteHead.enabled=false;
		} else {
			playerjson = json;

			labelName.text = json.PlayerName.ToString ();


			switch (json.PlayerQuality) {
			case 1:spriteCol.spriteName = "Player_player01";break;
			case 2:spriteCol.spriteName = "Player_player02";break;
			case 3:spriteCol.spriteName = "Player_player03";break;
			case 4:spriteCol.spriteName = "Player_player04";break;
			case 5:spriteCol.spriteName = "Player_player05";break;
			case 6:spriteCol.spriteName = "Player_player06";break;
			default:break;
			}
		}
	}
	public void onClick(){
		if (playerjson != null) {
			Data_PickPlayer_R.player data=new Data_PickPlayer_R.player(){
				id=playerjson.id,
				PlayerName=playerjson.PlayerName,
				PlayerPower=playerjson.PlayerPower,
				PlayerCategory=playerjson.PlayerCategory,
				PlayerPos=playerjson.PlayerPos,
				PlayerQuality=playerjson.PlayerQuality,
				Height=playerjson.Height,
				Weight=playerjson.Weight,
				Nationality=playerjson.Nationality,
				Role=playerjson.Role,
			};
			Globals.It.ShowPlayerSignView(data,2);
		}
	}
}