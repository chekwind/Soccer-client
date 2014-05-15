using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TacticsView:MonoBehaviour{
	public UIPanel panelstar1,panelpickup,panelbtns;
	public UILabel LabelTacticsPoint,LabelPower;

	private UISprite pick1,pick2,pick3,pick4,pick5,pick6,btnup1,btnup2,btnup3,btnup4,btnup5,btnup6,star1,star2,star3,star4,star5;

	public void show(){

		LabelTacticsPoint.text = "战术积分："+Globals.It.MainGamer.proMain.iTacticsPoint.ToString ();
		LabelPower.text= "球队实力："+Globals.It.MainGamer.proMain.iPower.ToString ();

		UISprite[] stars= panelstar1.GetComponentsInChildren<UISprite>();
		UISprite[] picks=panelpickup.GetComponentsInChildren<UISprite>();
		UISprite[] btns=panelbtns.GetComponentsInChildren<UISprite>();

		starlight (stars, 3);

		foreach( UISprite pick in picks){
			pick.enabled=false;
			switch(pick.name){
			case "Sprite1":pick1=pick;break;
			case "Sprite2":pick2=pick;break;
			case "Sprite3":pick3=pick;break;
			case "Sprite4":pick4=pick;break;
			case "Sprite5":pick5=pick;break;
			case "Sprite6":pick6=pick;break;
			default:break;
			}
		}
		foreach( UISprite btn in btns){
			switch(btn.name){
			case "Spritebtn1":btnup1=btn;break;
			case "Spritebtn2":btnup2=btn;break;
			case "Spritebtn3":btnup3=btn;break;
			case "Spritebtn4":btnup4=btn;break;
			case "Spritebtn5":btnup5=btn;break;
			case "Spritebtn6":btnup6=btn;break;
			default:break;
			}
		}

		btnup4.enabled =btnup5.enabled=btnup6.enabled= false;

		switch(Globals.It.MainGamer.proMain.iZenID){
		case 1:pick1.enabled=true;break;
		case 2:pick2.enabled=true;break;
		case 3:pick3.enabled=true;break;
		case 4:pick4.enabled=true;break;
		case 5:pick5.enabled=true;break;
		case 6:pick6.enabled=true;break;
		default:break;
		}
	}
	
	public void onClose(){
		Globals.It.DestoryTacticsView ();
		Globals.It.ShowLineUp ();
	}

	private void starlight(UISprite[] stars,int zenlv){
		foreach( UISprite star in stars){
			switch(star.name){
			case "Spritestar1":star1=star;break;
			case "Spritestar2":star2=star;break;
			case "Spritestar3":star3=star;break;
			case "Spritestar4":star4=star;break;
			case "Spritestar5":star5=star;break;
			default:break;
			}
		}
		switch(zenlv){
		case 1:star1.spriteName="Tactical_starLight";break;
		case 2:star1.spriteName=star2.spriteName="Tactical_starLight";break;
		case 3:star1.spriteName=star2.spriteName=star3.spriteName="Tactical_starLight";break;
		case 4:star1.spriteName=star2.spriteName=star3.spriteName=star4.spriteName="Tactical_starLight";break;
		case 5:star1.spriteName=star2.spriteName=star3.spriteName=star4.spriteName=star5.spriteName="Tactical_starLight";break;
		default:break;
		}
	}
}

