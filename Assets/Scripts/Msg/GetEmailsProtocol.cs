using UnityEngine;
using System.Collections;

public class GetEmailsProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_GetEmails_R data = Globals.ToObject<Data_GetEmails_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.ShowEmailsView(data.data);
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}else{
			Globals.It.NetManager.RoleLogin();
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.GetEmails;
		}
	}
}