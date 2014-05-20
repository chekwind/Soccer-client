using UnityEngine;
using System.Collections;

public class SuccessView : MonoBehaviour {
	
	public UILabel labelText;
	private bool isfinsh=false;

	void Start(){
		Invoke("close", 1);  
	}

	void Update(){
		if(isfinsh){
			Globals.It.HideSuccess ();
		}
	}

	public void show (string sText){
		labelText.text = sText.Trim();
	}
	public void close(){
		isfinsh = true;
	}
	void maskClick (){
		return;
	}
}
