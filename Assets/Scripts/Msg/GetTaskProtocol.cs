using UnityEngine;
using System.Collections;

public class GetTaskProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_GetTask_R data = Globals.ToObject<Data_GetTask_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.ShowTaskView(data.data);
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.GetTask;
		}
	}
}