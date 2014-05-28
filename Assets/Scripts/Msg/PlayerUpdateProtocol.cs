using UnityEngine;
using System.Collections;

public class PlayerUpdateProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_PlayerUpdate_R data = Globals.ToObject<Data_PlayerUpdate_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.RefreshPlayerList();
				Globals.It.RefreshPlayerView();
//				Globals.It.ShowSuccess(data.message);
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.PlayerUpdate;
		}
	}
}