using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System;

public class PlayerInnerView:MonoBehaviour{

	public UILabel labelbai, labelqian,labelpoint;
	public UIGrid gridParent;
	public GameObject gridChildItem;
	public UIPanel playerPanel;
	public UISprite sprite1,sprite2,sprite3,sprite4,sprite5;
	private List<InnerPlayer> m_Players = new List<InnerPlayer> ();
	private int cs1,cs2,ctime1,ctime2,cost,LeagueIndex;
	System.Timers.Timer timer = new Timer ();

	void Start(){
		timer.Elapsed += new ElapsedEventHandler (tick);
		timer.Interval=1000;
		timer.AutoReset=true;
		timer.Enabled=true;
	}
	
	void Update(){

	}
	private void tick(object source,System.Timers.ElapsedEventArgs e){
		if (cs1 == 0) {
			labelbai.text="抽取消耗点数：10";
		}
		else if (ctime1 > 0) {
			ctime1-=1;
			DateTime time=new DateTime();
			time=time.AddSeconds(ctime1);
			labelbai.text=time.ToString("hh:mm:ss")+"后免费";
		}else{
			labelbai.text="免费次数："+cs1.ToString();
		}
		if (cs2 == 0) {
			labelqian.text="抽取消耗点数：100";
		}
		else if (ctime2 > 0) {
			ctime2-=1;
			DateTime time=new DateTime();
			time=time.AddSeconds(ctime2);
			labelqian.text=time.ToString("hh:mm:ss")+"后免费";
		}else{
			labelqian.text="免费次数："+cs2.ToString();
		}
	}
	public void show(Data_PlayerInner_R.Data data,int leagueindex){

		GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
		InnerParent itemParent = gridItem.GetComponent<InnerParent> ();
		m_Players.AddRange (itemParent.Init ());
		NGUIUtility.SetParent (gridParent.transform, gridItem.transform);
		gridParent.Reposition ();

		SetData (data,leagueindex);
	}
	

	public void onPickBai(){
		if(isFull ()){
			Globals.It.ShowWarn (Const_ITextID.Msg_Tishi,"球员已满", null);
		}else{
			if (cs1 > 0 && ctime1==0) {
				cost=0;
			}else{
				cost=10;
			}
			Data_PickPlayer data = new Data_PickPlayer (){
				characterId=Globals.It.MainGamer.proMain.iCharacterId,
				picktype=1,
				leagueindex=LeagueIndex,
				costpoint=cost,
			};
			Globals.It.SendMsg (data, Const_ICommand.PickPlayer);
		}
	}
	public void onPickQian(){
		if(isFull ()){
			Globals.It.ShowWarn (Const_ITextID.Msg_Tishi,"球员已满", null);
		}else{
			if (cs2 > 0 && ctime2==0) {
				cost=0;
			}else{
				cost=100;
			}
			Data_PickPlayer data = new Data_PickPlayer (){
				characterId=Globals.It.MainGamer.proMain.iCharacterId,
				picktype=2,
				leagueindex=LeagueIndex,
				costpoint=cost,
			};
				Globals.It.SendMsg (data, Const_ICommand.PickPlayer);
		}
	}
	public void onPickWan(){
		if(isFull ()){
			Globals.It.ShowWarn (Const_ITextID.Msg_Tishi,"球员已满", null);
		}else{
			cost = 500;
			Data_PickPlayer data = new Data_PickPlayer (){
				characterId=Globals.It.MainGamer.proMain.iCharacterId,
				picktype=3,
				leagueindex=LeagueIndex,
				costpoint=cost,
			};
			Globals.It.SendMsg (data, Const_ICommand.PickPlayer);
		}
	}

	public void Refresh(){

		Data_PlayerInner data = new Data_PlayerInner (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
		};
		Globals.It.SendMsg (data, Const_ICommand.PlayerInner);
	}

	public void ReShow(Data_PlayerInner_R.Data data){

		Globals.It.DestoryPlayerInnerView ();
		Globals.It.ShowPlayerInnerView (data,LeagueIndex);
	}

	public void SetData(Data_PlayerInner_R.Data data,int leagueindex){
		labelpoint.text = "剩余点数：" + data.point.ToString();
		LeagueIndex = leagueindex;
		switch(LeagueIndex){
		case 1:sprite1.spriteName="Main_btn2_down";sprite2.spriteName=sprite3.spriteName=sprite4.spriteName=sprite5.spriteName="Main_btn2";break;
		case 2:sprite2.spriteName="Main_btn2_down";sprite1.spriteName=sprite3.spriteName=sprite4.spriteName=sprite5.spriteName="Main_btn2";break;
		case 3:sprite3.spriteName="Main_btn2_down";sprite2.spriteName=sprite1.spriteName=sprite4.spriteName=sprite5.spriteName="Main_btn2";break;
		case 4:sprite4.spriteName="Main_btn2_down";sprite2.spriteName=sprite3.spriteName=sprite1.spriteName=sprite5.spriteName="Main_btn2";break;
		case 5:sprite5.spriteName="Main_btn2_down";sprite2.spriteName=sprite3.spriteName=sprite4.spriteName=sprite1.spriteName="Main_btn2";break;
		default:break;
		}
		cs1 = data.cs1;
		cs2 = data.cs2;
		ctime1 = data.ctime1;
		ctime2 = data.ctime2;
	}
	public bool isFull(){
		int count = 0;
		foreach (PlayerJson json in Globals.It.MainGamer.proMain.lPlayerList) {
			if(json.PlayerCategory==3){
				count++;
			}
		}
		if(count==8){
			return true;
		}
		return false;
	}
	public void onLeagueIndex(GameObject sprite){
		switch(sprite.name){
		case "Sprite1":sprite1.spriteName="Main_btn2_down";sprite2.spriteName=sprite3.spriteName=sprite4.spriteName=sprite5.spriteName="Main_btn2";LeagueIndex=1;break;
		case "Sprite2":sprite2.spriteName="Main_btn2_down";sprite1.spriteName=sprite3.spriteName=sprite4.spriteName=sprite5.spriteName="Main_btn2";LeagueIndex=2;break;
		case "Sprite3":sprite3.spriteName="Main_btn2_down";sprite2.spriteName=sprite1.spriteName=sprite4.spriteName=sprite5.spriteName="Main_btn2";LeagueIndex=3;break;
		case "Sprite4":sprite4.spriteName="Main_btn2_down";sprite2.spriteName=sprite3.spriteName=sprite1.spriteName=sprite5.spriteName="Main_btn2";LeagueIndex=4;break;
		case "Sprite5":sprite5.spriteName="Main_btn2_down";sprite2.spriteName=sprite3.spriteName=sprite4.spriteName=sprite1.spriteName="Main_btn2";LeagueIndex=5;break;
		default:break;
		}

	}
	public void onClose(){
		Globals.It.DestoryPlayerInnerView ();
	}

}

