using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class CreateRoleView:MonoBehaviour{
	
	public UILabel labelName;
	
	public void show(){

	}
	public void onEnter(){
		string sRoleName = labelName.text.Trim();
		if (string.IsNullOrEmpty(sRoleName) || sRoleName.Length < 4||sRoleName.Length>12) {
			Globals.It.ShowWarn(Const_ITextID.Msg_Jinggao, 3, null);
			return;
		}
		System.Action sendMsg = () => {
			Data_CreateRole data = new Data_CreateRole()
			{
				userId=Globals.It.MainGamer.proMain.iUserID,
				rolename = sRoleName,
			};
			Globals.It.SendMsg(data, Const_ICommand.CreateRole);
		};
		Globals.It.ShowWaiting();
		if (!Globals.It.Connected) {
			Globals.It.Connect(sendMsg);
		}
		else {
			sendMsg();
		}
	}
	
}

