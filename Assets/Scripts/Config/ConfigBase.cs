using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerJson{
	public int id{ get; set; }
	public string PlayerName{ get; set; }
	public int PlayerPower{ get; set; }
	public int Role{ get; set; }
	public int PlayerQuality{ get; set;}
	public int PlayerCategory{ get; set; }
	public int Height{ get; set;}
	public int Weight{ get; set; }
	public string PlayerPos{ get; set; }
	public string Photo{ get; set; }
	public int Level{ get; set; }
	public string Nationality{ get; set;}
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
public class ItemJson{
	public int itemid{ get; set; }
	public int stack{ get; set; }
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

	public int cost{ get; set; }
	
}
public abstract class ConfigBase:MonoBehaviour{
	public abstract string sPath {
		get;
	}
	public abstract void Parse(Object asset);

	void Start(){
		gameObject.isStatic = true;
		enabled = false;

		_LoadConfig ();
	}
	void _LoadConfig(){
		StartCoroutine(Globals.It.BundleMgr.CreateObject(kResource.Config,Const_SPath.Path_Config,sPath,Parse));
	}
}