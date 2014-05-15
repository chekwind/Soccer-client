using UnityEngine;
using System.Collections;

public class Gamer:MonoBehaviour{
	public GamerPropertyMain proMain{ get; private set; }

	void Awake(){
		proMain = new GamerPropertyMain ();
	}
}
