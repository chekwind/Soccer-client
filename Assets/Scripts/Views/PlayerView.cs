using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class PlayerView:MonoBehaviour{

	public UILabel labelName, labelPower, labelLevel,labelRole,labelPlayerQuality,labelNationality,labelShoot,labelDribbling,labelSpeed,labelPass,labelTackle,labelTackling,labelSave,labelResponse,labelTrainPoint;
	public UISlider PlayerExpSlider,ShootSlider,DribblingSlider,PassSlider,SpeedSlider,TackleSlider,TacklingSlider,SaveSlider,ResponseSliser;
	public UISprite spriteHeadCol,spriteshoot,spritedribbling,spritespeed,spritepass,spritetackle,spritetackling,spritesave,spriteresponse;
	public UIImageButton btnDismiss,btnSave;
	private PlayerJson playerjson=new PlayerJson();
	private bool isontouch;
	private int attr,needpoint,trainpoint;
	private bool isfull=false;
	System.Timers.Timer timer = new Timer ();

	void Start(){
				timer.Elapsed += new ElapsedEventHandler (add);
		}
	
	void Update(){
				if (isontouch == true) {
						ShootSlider.sliderValue = (float)(Convert.ToInt32 (labelShoot.text)) / playerjson.MaxShoot;
						DribblingSlider.sliderValue = (float)(Convert.ToInt32 (labelDribbling.text)) / playerjson.MaxDribbling;
						PassSlider.sliderValue = (float)(Convert.ToInt32 (labelPass.text)) / playerjson.MaxPass;
						SpeedSlider.sliderValue = (float)(Convert.ToInt32 (labelSpeed.text)) / playerjson.MaxSpeed;
						TacklingSlider.sliderValue = (float)(Convert.ToInt32 (labelTackling.text)) / playerjson.MaxTackling;
						TackleSlider.sliderValue = (float)(Convert.ToInt32 (labelTackle.text)) / playerjson.MaxTackle;
						SaveSlider.sliderValue = (float)(Convert.ToInt32 (labelSave.text)) / playerjson.MaxSave;
						ResponseSliser.sliderValue = (float)(Convert.ToInt32 (labelResponse.text)) / playerjson.MaxResponse;
						btnSave.isEnabled = true;
				}
				if (isfull == true) {
					Globals.It.ShowSuccess("球员属性已满");
					isfull=false;
				}
		}
	public void show(PlayerJson json,int sign){
		playerjson = json;
		labelName.text = json.PlayerName.ToString();
		labelLevel.text ="Lv "+json.Level.ToString();
		labelPower.text ="能力"+ json.PlayerPower.ToString();
		labelNationality.text = json.Nationality.ToString ();
		labelShoot.text = json.Shoot.ToString ();
		labelDribbling.text = json.Dribbling.ToString ();
		labelSpeed.text = json.Speed.ToString ();
		labelPass.text = json.Pass.ToString ();
		labelTackle.text = json.Tackle.ToString ();
		labelTackling.text = json.Tackling.ToString ();
		labelSave.text = json._Save.ToString ();
		labelResponse.text = json.Response.ToString ();
		labelTrainPoint.text="全队训练点："+Globals.It.MainGamer.proMain.iTrainPoint.ToString();
		trainpoint = Globals.It.MainGamer.proMain.iTrainPoint;
		PlayerExpSlider.sliderValue = json.Exp / json.MaxExp;
		ShootSlider.sliderValue = json.Shoot / json.MaxShoot;
		DribblingSlider.sliderValue = json.Dribbling / json.MaxDribbling;
		PassSlider.sliderValue = json.Pass / json.MaxPass;
		SpeedSlider.sliderValue = json.Speed / json.MaxSpeed;
		TackleSlider.sliderValue = json.Tackle / json.MaxTackle;
		TacklingSlider.sliderValue = json.Tackling / json.MaxTackling;
		SaveSlider.sliderValue = json._Save / json.MaxSave;
		ResponseSliser.sliderValue = json.Response / json.MaxResponse;

		if (sign == 1) {
			btnDismiss.gameObject.SetActive(false);
			btnSave.gameObject.SetActive(false);
			labelTrainPoint.enabled=false;
			spriteshoot.GetComponent<BoxCollider>().enabled=false;
			spritedribbling.GetComponent<BoxCollider>().enabled=false;
			spritepass.GetComponent<BoxCollider>().enabled=false;
			spritespeed.GetComponent<BoxCollider>().enabled=false;
			spritetackling.GetComponent<BoxCollider>().enabled=false;
			spritetackle.GetComponent<BoxCollider>().enabled=false;
			spritesave.GetComponent<BoxCollider>().enabled=false;
			spriteresponse.GetComponent<BoxCollider>().enabled=false;
		}
		btnDismiss.isEnabled = false;
		btnSave.isEnabled = false;
		if (json.PlayerCategory == 2) {
			btnDismiss.isEnabled = true;
		}



		switch(json.Role){
		case 1:labelRole.text="门将";labelSave.color=labelResponse.color=Color.yellow;break;
		case 2:labelRole.text="后卫";labelTackle.color=labelTackling.color=Color.yellow;break;
		case 3:labelRole.text="中场";labelPass.color=labelSpeed.color=Color.yellow;break;
		case 4:labelRole.text="前锋";labelShoot.color=labelDribbling.color=Color.yellow;break;
		default:break;
		}
		
		switch(json.PlayerQuality){
		case 1:spriteHeadCol.spriteName="Player_player01";
			labelPlayerQuality.text="一般";
			spriteshoot.spriteName=spritedribbling.spriteName=spritespeed.spriteName=spritepass.spriteName=spritetackle.spriteName=spritetackling.spriteName=spritesave.spriteName=spriteresponse.spriteName="Player_attk01";
			break;
		case 2:spriteHeadCol.spriteName="Player_player02";
			labelPlayerQuality.text="优秀";
			spriteshoot.spriteName=spritedribbling.spriteName=spritespeed.spriteName=spritepass.spriteName=spritetackle.spriteName=spritetackling.spriteName=spritesave.spriteName=spriteresponse.spriteName="Player_attk02";
			break;
		case 3:spriteHeadCol.spriteName="Player_player03";
			labelPlayerQuality.text="精英";
			spriteshoot.spriteName=spritedribbling.spriteName=spritespeed.spriteName=spritepass.spriteName=spritetackle.spriteName=spritetackling.spriteName=spritesave.spriteName=spriteresponse.spriteName="Player_attk03";
			break;
		case 4:spriteHeadCol.spriteName="Player_player04";
			labelPlayerQuality.text="杰出";
			spriteshoot.spriteName=spritedribbling.spriteName=spritespeed.spriteName=spritepass.spriteName=spritetackle.spriteName=spritetackling.spriteName=spritesave.spriteName=spriteresponse.spriteName="Player_attk04";
			break;
		case 5:spriteHeadCol.spriteName="Player_player05";
			labelPlayerQuality.text="大牌";
			spriteshoot.spriteName=spritedribbling.spriteName=spritespeed.spriteName=spritepass.spriteName=spritetackle.spriteName=spritetackling.spriteName=spritesave.spriteName=spriteresponse.spriteName="Player_attk05";
			break;
		case 6:spriteHeadCol.spriteName="Player_player06";
			labelPlayerQuality.text="巨星";
			spriteshoot.spriteName=spritedribbling.spriteName=spritespeed.spriteName=spritepass.spriteName=spritetackle.spriteName=spritetackling.spriteName=spritesave.spriteName=spriteresponse.spriteName="Player_attk06";
			break;
		default:break;
		}
	}

	public void onClose(){
		Globals.It.DestoryPlayerView ();
	}
	public void onDrop(){
		Data_DropPlayer data = new Data_DropPlayer (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
			playerId=playerjson.id
		};
		Globals.It.SendMsg (data, Const_ICommand.DropPlayer);
	}
	public void onSave(){
				Data_PlayerTraining data = new Data_PlayerTraining (){
				characterId=Globals.It.MainGamer.proMain.iCharacterId,
				playerid=playerjson.id,
				shoot=Convert.ToInt32(labelShoot.text),
				dribbling=Convert.ToInt32(labelDribbling.text),
				pass=Convert.ToInt32(labelPass.text),
				speed=Convert.ToInt32(labelSpeed.text),
				tackling=Convert.ToInt32(labelTackling.text),
				tackle=Convert.ToInt32(labelTackle.text),
				save=Convert.ToInt32(labelSave.text),
				response=Convert.ToInt32(labelResponse.text),
				trainpoint=needpoint
			};
		btnSave.isEnabled = false;
		Globals.It.SendMsg (data, Const_ICommand.PlayerTraining);
	}
	public void onPress(GameObject button){
		isontouch = true;
		timer.Start ();
		timer.Interval=100;
		timer.AutoReset=true;
		timer.Enabled=true;
		switch (button.name) {
		case "shoot":attr=1;break;
		case "dribbling":attr=2;break;
		case "pass":attr=3;break;
		case "speed":attr=4;break;
		case "tackling":attr=5;break;
		case "tackle":attr=6;break;
		case "save":attr=7;break;
		case "response":attr=8;break;
		default:break;
		}
	}
	public void onRelease(){
		isontouch = false;
		timer.Stop ();
		timer.Enabled = false;
	}
	public void Refresh(){
		show(playerjson,2);
	}
	public void add(object source,System.Timers.ElapsedEventArgs e){
		if (isontouch) {
			switch(attr){
			case 1:attributeAdd(labelShoot,playerjson.MaxShoot);break;
			case 2:attributeAdd(labelDribbling,playerjson.MaxDribbling);break;
			case 3:attributeAdd(labelPass,playerjson.MaxPass);break;
			case 4:attributeAdd(labelSpeed,playerjson.MaxSpeed);break;
			case 5:attributeAdd(labelTackling,playerjson.MaxTackling);break;
			case 6:attributeAdd(labelTackle,playerjson.MaxTackle);break;
			case 7:attributeAdd(labelSave,playerjson.MaxSave);break;
			case 8:attributeAdd(labelResponse,playerjson.MaxResponse);break;
			default:break;
			}
		}
	}
	private void attributeAdd(UILabel label,float max){
		int attribute=Convert.ToInt32 (label.text);
		trainpoint-=(attribute+51)/5;
		if(attribute<max&&trainpoint>0){
			needpoint+=(attribute+51)/5;
			label.text="全队训练点："+trainpoint.ToString();
			label.text = (attribute + 1).ToString ();
		}else if(trainpoint<0){
			Debug.Log("dian shu bu gou");
			isontouch=false;
		}else{
			isfull=true;
			isontouch=false;
		}
	}
}