using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainMatchNPC:MonoBehaviour{

	public UILabel labelname;
	public UISprite spritehead, spritebg;
	

	public void SetData(Data_GetTrainMatch_R.NPC npc){
		switch (npc.LeagueIndex) {
		case 1:spritebg.spriteName="TrainMatch_001";break;
		case 2:spritebg.spriteName="TrainMatch_002";break;
		case 3:spritebg.spriteName="TrainMatch_003";break;
		case 4:spritebg.spriteName="TrainMatch_004";break;
		case 5:spritebg.spriteName="TrainMatch_005";break;
		}
		spritehead.spriteName = npc.ClubLogo;
		labelname.text = npc.ClubName;
	}
	public void onClick(){
		Debug.Log ("1111");
	}
}