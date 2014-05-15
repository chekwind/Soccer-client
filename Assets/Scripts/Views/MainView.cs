using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainView:MonoBehaviour{
	
	public GamerStat gamerStat;

	void Start(){
		RefreshGamerStat ();
	}

	void onBag(){
		Data_BagInfo data = new Data_BagInfo (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
		};
		Globals.It.SendMsg (data, Const_ICommand.BagInfo);
	}
	void onChat(){
		Globals.It.ShowWarn (1, 13, null);
	}
	void onFuli(){
		Globals.It.ShowWarn (1, 13, null);
	}
	void onMail(){
		Globals.It.ShowWarn (1, 13, null);
	}
	void onManage(){
		Globals.It.ShowLineUp();
	}
	void onRank(){
		Globals.It.ShowWarn (1, 13, null);
	}
	void onQiutan(){
		Data_PlayerInner data = new Data_PlayerInner (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
		};
		Globals.It.SendMsg (data, Const_ICommand.PlayerInner);
	}
	void onTask(){
		Globals.It.ShowWarn (1, 13, null);
	}
	void onTrade(){
		Globals.It.ShowWarn (1, 13, null);
	}
	void onShop(){
		Data_StoreInfo data = new Data_StoreInfo (){
			characterId=Globals.It.MainGamer.proMain.iCharacterId,
			shopCategory=1,
		};
		Globals.It.SendMsg (data, Const_ICommand.StoreInfo);
	}
	void onMatch(){
		Globals.It.ShowWarn (1, 13, null);
	}
	public void RefreshGamerStat(){
		gamerStat.Refresh ();
	}
}