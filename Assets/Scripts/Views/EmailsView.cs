using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EmailsView:MonoBehaviour{

	public UIGrid gridParent;
	public GameObject gridChildItem;
	public UIPanel emailsPanel;

	private List<Email> m_Emails = new List<Email> ();

	public void show(Data_GetEmails_R.Data mails){

		int iMailCount = mails.maillist.Length;
		int iObjectCount = iMailCount / 3;
		int iend = iMailCount % 3;
		if (iend != 0) {
			iObjectCount+=1;
		}
		int iPos = 0, iOffset = 0;
		for (; iPos<iObjectCount; iPos++) {
			GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
			EmailsParent itemParent = gridItem.GetComponent<EmailsParent> ();
			if(iMailCount>=(iPos+1)*3){
				m_Emails.AddRange (itemParent.Init (iOffset,iOffset+2,mails));
				iOffset+=3;
			}else{
				m_Emails.AddRange (itemParent.Init (iOffset,iOffset+iend-1,mails));
			}
			NGUIUtility.SetParent (gridParent.transform, gridItem.transform);
		}
		gridParent.Reposition ();

	}

	public void onClose(){
		Globals.It.DestoryEmailsView ();
	}
	
}

