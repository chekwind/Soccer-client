using UnityEngine;
using System.Collections;

public class PlayerInnerProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_PlayerInner_R data = Globals.ToObject<Data_PlayerInner_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.ShowPlayerInnerView(data.data,1);
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.PlayerInner;
		}
	}
}