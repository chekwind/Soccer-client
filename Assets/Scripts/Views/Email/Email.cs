using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Email:MonoBehaviour{
	
	public UILabel labeltitle, labelcontent;
	
	public void SetData(Data_GetEmails_R.maillist mail){
		labeltitle.text = mail.title.ToString ();
		labelcontent.text = mail.content.ToString ();

	}
	public void onClick(){

	}
}