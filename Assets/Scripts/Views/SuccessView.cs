using UnityEngine;
using System.Collections;
using System.Timers;

public class SuccessView : MonoBehaviour {
	
	public UILabel labelText;
	private bool isfinsh=false;
	System.Timers.Timer timer = new Timer ();

	void Start(){
		timer.Elapsed += new ElapsedEventHandler (close);
		timer.Start ();
		timer.Interval=1500;
		timer.AutoReset=true;
		timer.Enabled=true;
	}

	void Update(){
		if(isfinsh){
			Globals.It.HideSuccess ();
		}
	}

	public void show (string sText){
		labelText.text = sText.Trim();
	}
	public void close(object source,System.Timers.ElapsedEventArgs e){
		isfinsh = true;
	}
	void maskClick (){
		return;
	}
}
