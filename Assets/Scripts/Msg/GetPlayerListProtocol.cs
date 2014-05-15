using UnityEngine;
using System.Collections;

public class GetPlayerListProtocol:IProtocol{

	public void Process(Message_Body info){
		Data_PlayerList_R data = Globals.ToObject<Data_PlayerList_R> (info.body);
		if (data != null) {
			if (data.result) {
				Globals.It.MainGamer.proMain.SetPlayerList (data.data);
				Globals.It.ShowMainView ();
			} else {
				Globals.It.HideWaiting ();
				Globals.It.ShowWarn (Const_ITextID.Msg_Tishi, data.message, null);
			}
		} else {
			Globals.It.HideWaiting();
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.GetPlayerList;
		}
	}
}