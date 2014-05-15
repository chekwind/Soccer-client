using UnityEngine;
using System.Collections;

public class SignPlayerProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_SignPlayer_R data = Globals.ToObject<Data_SignPlayer_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.DestoryPlayerSignView ();
				Globals.It.MainGamer.proMain.bNeedRefresh=true;
				Globals.It.RefreshPlayerList();
				Globals.It.ShowMainView();	
				Globals.It.RefreshPlayerInnerView();
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.SignPlayer;
		}
	}
}