using UnityEngine;
using System.Collections;

public class BagInfoProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_BagInfo_R data = Globals.ToObject<Data_BagInfo_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.MainGamer.proMain.SetBagItemList(data.data);
				Globals.It.ShowBagView();
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.BagInfo;
		}
	}
}