using UnityEngine;
using System.Collections;

public class CreateRoleProtocol : IProtocol {
	
	#region IProtocol implementation
	public void Process (Message_Body info)
	{
		Data_CreateRole_R data = Globals.ToObject<Data_CreateRole_R>(info.body);
		if(data != null) {
			if (data.result) {
				Globals.It.DestoryCreateRoleView();
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
			return Const_ICommand.CreateRole;
		}
	}
	#endregion
	
}
