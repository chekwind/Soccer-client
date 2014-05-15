using UnityEngine;
using System.Collections;

public class PlayerRotateProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_PlayerRotate_R data = Globals.ToObject<Data_PlayerRotate_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.MainGamer.proMain.bNeedRefresh=true;
				Globals.It.RefreshPlayerList();
				Globals.It.ShowMainView();
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
				Globals.It.Rotate(0,0);
			}
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.PlayerRotate;
		}
	}
}