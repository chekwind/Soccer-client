using UnityEngine;
using System.Collections;

public class Data_Base{}


public class Data_UserLogin:Data_Base
{
	public string username{ get; set; }
	public string password{ get; set; }
}
public class Data_UserLogin_R:Data_Base
{
	public class Data{
		public int userId{ get; set; }
		public bool hasRole{ get; set; }
		public int characterId{ get; set; }
	}
	public bool result { get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}
public class Data_RoleEnterGame:Data_Base
{
	public int characterId{ get; set; }
}
public class Data_RoleEnterGame_R:Data_Base
{
	public class Data{
		public string name{ get; set; }
		public int power{ get; set; }
		public int characterid{ get; set; }
		public int level{ get; set; }
		public int exp{ get; set; }
		public int maxexp{ get; set; }
		public int gamecoin{ get; set; }
		public int coin{ get; set; }
		public string photo{ get; set; }
		public int energy{ get; set; }
		public int repute { get; set; }
		public int trainpoint{ get; set; }
		public int zenid{ get; set; }
		public int tacticspoint{ get; set; }
	}

	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}
public class Data_GamerStat:Data_Base
{
	public int characterId{get;set;}
}
public class Data_GamerStat_R:Data_Base
{
	public class Data{
		public string rolename{ get; set; }
		public int power{ get; set; }
		public int characterId{ get; set; }
		public int level{ get; set; }
		public int exp{ get; set; }
		public int maxexp{ get; set; }
		public int gamecoin{ get; set; }
		public int coin{ get; set; }
		public string photo{ get; set; }
		public int energy{ get; set; }
		public int maxenergy{ get; set; }
		public int trainpoint{ get; set; }
		public int repute { get; set; }
		public int zenid{ get; set; }
		public int tacticspoint{ get; set; }
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}

public class Data_PlayerList_R:Data_Base
{
	public class Data{
		public playerlist[] playerlist{ get; set; }
	}
	public class playerlist{
		public int id{ get; set; }
		public string PlayerName{ get; set; }
		public int PlayerPower{ get; set; }
		public int Role{ get; set; }
		public int PlayerQuality{ get; set; }
		public int PlayerCategory{ get; set; }
		public int Height{ get; set;}
		public int Weight{ get; set; }
		public string PlayerPos{ get; set; }
		public int Level{ get; set; }
		public string Nationality{ get; set; }
		public float Shoot{ get; set; }
		public float Dribbling{ get; set; }
		public float Pass{ get; set; }
		public float Speed{ get; set; }
		public float Tackling{ get; set; }
		public float Tackle{ get; set; }
		public float _Save{ get; set; }
		public float Response{ get; set; }
		public float MaxShoot{ get; set; }
		public float MaxDribbling{ get; set; }
		public float MaxPass{ get; set; }
		public float MaxSpeed{ get; set; }
		public float MaxTackling{ get; set; }
		public float MaxTackle{ get; set; }
		public float MaxSave{ get; set; }
		public float MaxResponse{ get; set; }
		public float Exp{ get; set;}
		public float MaxExp{ get; set; }
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}

public class Data_PlayerRotate:Data_Base
{
	public int characterId{ get; set; }
	public int mainPlayerId{ get; set; }
	public int benchPlayerId{ get; set; }

}
public class Data_PlayerRotate_R:Data_Base
{
	public class Data{
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
	
}
public class Data_PlayerTraining:Data_Base
{
	public int characterId{ get; set; }
	public int playerid{ get; set; }
	public int shoot{ get; set; }
	public int dribbling{ get; set; }
	public int speed{ get; set; }
	public int pass{ get; set; }
	public int tackle{ get; set; }
	public int tackling{ get; set; }
	public int save{ get; set; }
	public int response{ get; set; }
	public int trainpoint{ get; set; }
	
}
public class Data_PlayerTraining_R:Data_Base
{
	public class Data{

	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
	
}
public class Data_DropPlayer:Data_Base
{
	public int characterId{ get; set; }
	public int playerId{ get; set; }
}
public class Data_DropPlayer_R:Data_Base
{
	public class Data{
		
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
	
}

public class Data_PlayerInner:Data_Base
{
	public int characterId{ get; set; }
}
public class Data_PlayerInner_R:Data_Base
{
	public class Data{
		public int player1{ get; set; }
		public int player2{ get; set; }
		public int player3{ get; set; }
		public int point{ get; set; }
		public int xy{ get; set; }
		public int cs1{ get; set; }
		public int cs2{ get; set; }
		public int ctime1{ get; set; }
		public int ctime2{ get; set; }
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
	
}

public class Data_PickPlayer:Data_Base
{
	public int characterId{ get; set; }
	public int picktype{ get; set; }
	public int costpoint{ get; set; }
	public int leagueindex{ get; set; }
}
public class Data_PickPlayer_R:Data_Base
{
	public class Data{
		public player player{ get; set; } 
	}
	public class player{
		public int id{ get; set; }
		public string PlayerName{ get; set; }
		public int PlayerPower{ get; set; }
		public int Role{ get; set; }
		public int PlayerQuality{ get; set; }
		public int PlayerCategory{ get; set; }
		public string PlayerPos{ get; set; }
		public string Nationality{ get; set; }
		public int Height{ get; set; }
		public int Weight{ get; set; }
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
	
}

public class Data_DismissPlayer:Data_Base
{
	public int characterId{ get; set; }
	public int playerId{ get; set; }
}
public class Data_DismissPlayer_R:Data_Base
{
	public class Data{
		
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
	
}

public class Data_SignPlayer:Data_Base
{
	public int characterId{ get; set; }
	public int playerId{ get; set; }
	public int gamecoin{ get; set; }
}
public class Data_SignPlayer_R:Data_Base
{
	public class Data{
		
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}
public class Data_BagInfo:Data_Base
{
	public int characterId{ get; set; }
}
public class Data_BagInfo_R:Data_Base
{
	public class Data{
		public itemlist[] itemlist{ get; set; }
	}
	public class itemlist{
		public int itemid{ get; set; }
		public temp tempinfo{ get; set; }
		public int stack{ get; set; }
	}
	public class temp{
		public int maxsatck{ get; set; }
		public int ItemPage{ get; set; }
		public string Description{ get; set; }
		public int Type{ get; set; }
		public int UseType{ get; set; }
		public int Compound{ get; set; }
		public int ComPrice{ get; set; }
		public string Icon{ get; set;}
		public string ItemName{ get; set; }
		public string UseMethod{ get; set; }
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}
public class Data_StoreInfo:Data_Base
{
	public int characterId{ get; set; }
	public int shopCategory{ get; set; }
}
public class Data_StoreInfo_R:Data_Base
{
	public class Data{
		public items[] items{ get; set; }
	}
	public class items{
		public int id{ get; set; }
		public int singlecount{ get; set; }
		public int allcount{ get; set; }
		public int cost{ get; set; }
		public int position{ get; set; }
		public item item{ get; set; }

	}
	public class item{
		public int maxsatck{ get; set; }
		public int ItemPage{ get; set; }
		public string Description{ get; set; }
		public int Type{ get; set; }
		public int UseType{ get; set; }
		public int Compound{ get; set; }
		public int ComPrice{ get; set; }
		public string Icon{ get; set;}
		public string ItemName{ get; set; }
		public string UseMethod{ get; set; }
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}
public class Data_BuyItem:Data_Base
{
	public int characterId{ get; set; }
	public int shopCategory{ get; set; }
	public int itemId{ get; set; }
	public int buyNum{ get; set; }
}
public class Data_BuyItem_R:Data_Base
{
	public class Data{
		
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}
public class Data_UseItem:Data_Base
{
	public int characterId{ get; set; }
	public int itemId{ get; set; }
	public int targetId{ get; set; }
}
public class Data_UseItem_R:Data_Base
{
	public class Data{
		
	}
	public bool result{ get; set; }
	public string message{ get; set; }
	public Data data{ get; set; }
}