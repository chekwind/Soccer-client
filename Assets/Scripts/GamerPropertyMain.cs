using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamerPropertyMain  {

	public int 		iUserID { get; set; }
	public int 		iCharacterId { get; set; }
	public bool		bHasRole { get; set; }
	public string 	sRoleName { get; set; }
	public int 		iLevel { get; set; }
	public float 	fExp { get; set; }
	public float 	fMaxExp { get; set; }
	public int 		iGameCoin { get; set; }
	public int 		iCoin { get; set; }
	public int 		iRepute { get; set; }
	public int 		iEnergy { get; set; }
	public string sPhoto{ get; set; }
	public int iPower{ get; set; }
	public int iTrainPoint{ get; set; }
	public int iZenID{ get; set; }
	public int iTacticsPoint{ get; set;}
	public List<PlayerJson> lPlayerList = new List<PlayerJson> ();
	public List<ItemJson> lBagItemList = new List<ItemJson> ();
	public List<ItemJson> lStoreItemList = new List<ItemJson> ();
	public List<PlayerJson> rotateplayer = new List<PlayerJson> ();
	public PlayerJson playertemp = new PlayerJson();
	
	public bool		bNeedRefresh { get; set; }		// Refresh Player stat
	
	public void SetLogin(Data_UserLogin_R.Data data){
		iUserID = data.userId;
	}
	public void SetRoleEnterGame(Data_RoleEnterGame_R.Data data){

		iCharacterId = data.characterid;
		sRoleName = data.name;
		iLevel = data.level;
		fExp = data.exp;
		fMaxExp = data.maxexp;
		iGameCoin = data.gamecoin;
		iCoin = data.coin;
		iRepute = data.repute;
		iEnergy = data.energy;
		sPhoto = data.photo;
		iPower = data.power;
		iTrainPoint = data.trainpoint;
		iZenID = data.zenid;
		iTacticsPoint = data.tacticspoint;
		bNeedRefresh = false;
	}

	public void UpdateStat(Data_GamerStat_R.Data data){
		iCharacterId = data.characterId;
		sRoleName = data.rolename;
		iLevel = data.level;
		fExp = data.exp;
		fMaxExp = data.maxexp;
		iGameCoin = data.gamecoin;
		iCoin = data.coin;
		iRepute = data.repute;
		iEnergy = data.energy;
		sPhoto = data.photo;
		iPower = data.power;
		iTrainPoint = data.trainpoint;
		iZenID = data.zenid;
		iTacticsPoint = data.tacticspoint;
		bNeedRefresh = false;
	}
	public void SetPlayerList(Data_PlayerList_R.Data data){
		lPlayerList.Clear();
		Data_PlayerList_R.playerlist[] pl = data.playerlist;
		foreach (Data_PlayerList_R.playerlist player in pl) {
			PlayerJson pj=new PlayerJson();
			pj.id=player.id;
			pj.PlayerName=player.PlayerName;
			pj.Photo=player.Photo;
			pj.PlayerPower=player.PlayerPower;
			pj.Role=player.Role;
			pj.PlayerQuality=player.PlayerQuality;
			pj.PlayerCategory=player.PlayerCategory;
			pj.Height=player.Height;
			pj.Weight=player.Weight;
			pj.PlayerPos=player.PlayerPos;
			pj.Level=player.Level;
			pj.Nationality=player.Nationality;
			pj.Shoot=player.Shoot;
			pj.Dribbling=player.Dribbling;
			pj.Speed=player.Speed;
			pj.Pass=player.Pass;
			pj.Tackle=player.Tackle;
			pj.Tackling=player.Tackling;
			pj._Save=player._Save;
			pj.Response=player.Response;
			pj.MaxShoot=player.MaxShoot;
			pj.MaxDribbling=player.MaxDribbling;
			pj.MaxSpeed=player.MaxSpeed;
			pj.MaxPass=player.MaxPass;
			pj.MaxTackle=player.MaxTackle;
			pj.MaxTackling=player.MaxTackling;
			pj.MaxSave=player.MaxSave;
			pj.MaxResponse=player.MaxResponse;
			pj.Exp=player.Exp;
			pj.MaxExp=player.MaxExp;
			lPlayerList.Add(pj);
		}
	}
	public void SetBagItemList(Data_BagInfo_R.Data data){
		lBagItemList.Clear();
		Data_BagInfo_R.itemlist[] il = data.itemlist;
		foreach (Data_BagInfo_R.itemlist item in il) {
			ItemJson ij=new ItemJson();
			ij.itemid=item.itemid;
			ij.ItemName=item.tempinfo.ItemName;
			ij.stack=item.stack;
			ij.Icon=item.tempinfo.Icon;
			ij.Type=item.tempinfo.Type;
			ij.ItemPage=item.tempinfo.ItemPage;
			ij.UseType=item.tempinfo.UseType;
			lBagItemList.Add(ij);
		}
	}
	public void SetStoreItemList(Data_StoreInfo_R.Data data){
		lStoreItemList.Clear();
		Data_StoreInfo_R.items[] il = data.items;
		foreach (Data_StoreInfo_R.items item in il) {
			ItemJson ij=new ItemJson();
			ij.itemid=item.id;
			ij.ItemName=item.item.ItemName;
			ij.cost=item.cost;
			ij.Icon=item.item.Icon;
			ij.Description=item.item.Description;
			lStoreItemList.Add(ij);
		}
	}
}
