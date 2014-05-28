using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EmailsParent:MonoBehaviour
{
	public Email email;

	private Vector3[] emailsPos={
		new Vector3(-10,25,0),
		new Vector3(227,25,0),
		new Vector3(463,25,0),
	};
	
	public Email[] Init (int iStart,int iEnd,Data_GetEmails_R.Data mails){
		Email[] emails=new Email[iEnd-iStart+1];
		for(int i=0;i<iEnd-iStart+1;i++){
			emails[i]=(Email)GameObject.Instantiate (email);
			emails[i].SetData (mails.maillist[iStart+i]);
			NGUIUtility.SetParent (transform, emails[i].transform);
			emails[i].transform.localPosition = emailsPos [i];
		}
		return emails;
	}
}

