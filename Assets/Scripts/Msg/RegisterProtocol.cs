using UnityEngine;
using System.Collections;

public class RegisterProtocol : IProtocol {
	
	#region IProtocol implementation
	public void Process (Message_Body info)
	{
		Data_UserLogin_R data = Globals.ToObject<Data_UserLogin_R>(info.body);
		if(data != null) {
			if (data.result) {
				Globals.It.DestoryDengluView();
				Globals.It.MainGamer.proMain.SetLogin(data.data);
				Globals.It.ShowEnterGameView();
				
			}
			else {
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi, data.message, null);
			}
		}
	}
	
	public int iCommand {
		get {
			return Const_ICommand.UserRegister;
		}
	}
	#endregion
	
}
