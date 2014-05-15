using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player:MonoBehaviour{
	
	public UILabel labelName,labelPower,labelRole;
	public UISprite spriteCol,spriteHead,spriteClick;

	private PlayerJson playerjosn;
	
	public void SetData(PlayerJson json){
		if (json == null) {
			labelName.enabled=false;
			labelPower.enabled=false;
			labelRole.enabled=false;
			spriteHead.enabled=false;
			spriteCol.enabled=false;
			spriteHead.enabled=false;
			spriteClick.enabled=false;
		} else {
			playerjosn = json;

			labelName.text = json.PlayerName.ToString ();
			labelPower.text = json.PlayerPower.ToString ();
			spriteClick.enabled=false;

			switch (json.Role) {
			case 1:labelRole.text = "门将";break;
			case 2:labelRole.text = "后卫";break;
			case 3:labelRole.text = "中场";break;
			case 4:labelRole.text = "前锋";break;
			default:break;
			}
			switch (json.PlayerQuality) {
			case 1:spriteCol.spriteName = "Public_Player01";break;
			case 2:spriteCol.spriteName = "Public_Player02";break;
			case 3:spriteCol.spriteName = "Public_Player03";break;
			case 4:spriteCol.spriteName = "Public_Player04";break;
			case 5:spriteCol.spriteName = "Public_Player05";break;
			case 6:spriteCol.spriteName = "Public_Player06";break;
			default:break;
			}
		}
	}
	public void onClick(){
		List<PlayerJson> players = new List<PlayerJson> ();
		int mainplayer=0, benchplayer=0;
		players = Globals.It.MainGamer.proMain.rotateplayer;
		if(playerjosn==null){
			spriteClick.enabled=false;
		}
		else if (players.Contains (playerjosn)) {
			spriteClick.enabled=false;
			Globals.It.MainGamer.proMain.rotateplayer.Clear();
		}
		else if(players.Count==0){
			Globals.It.MainGamer.proMain.rotateplayer.Add(playerjosn);
			spriteClick.enabled=true;
		}
		else if(players.Count==1){
			Globals.It.MainGamer.proMain.rotateplayer.Add(playerjosn);
			foreach(PlayerJson player in players){
				if(player.PlayerPos=="z"){
					benchplayer=player.id;
				}else if(mainplayer!=0){
					benchplayer=player.id;
				}else{
					mainplayer=player.id;
				}
			}
			Globals.It.Rotate(mainplayer,benchplayer);
			Globals.It.MainGamer.proMain.rotateplayer.Clear();
		}
		else{
			spriteClick.enabled=false;
		}
	}
}