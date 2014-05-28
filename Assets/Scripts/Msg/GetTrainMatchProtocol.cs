using UnityEngine;
using System.Collections;

public class GetTrainMatchProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_GetTrainMatch_R data = Globals.ToObject<Data_GetTrainMatch_R> (info.body);
		if (data != null) {
			if (data.result) {
				Globals.It.DestoryGameCenter();
				Globals.It.ShowTrainMatchView(data.data);
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
			return Const_ICommand.GetTrainMatch;
		}
	}
}