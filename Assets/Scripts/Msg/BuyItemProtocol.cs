using UnityEngine;
using System.Collections;

public class BuyItemProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_BuyItem_R data = Globals.ToObject<Data_BuyItem_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.DestoryBuyView();
				Globals.It.MainGamer.proMain.bNeedRefresh=true;
				Globals.It.ShowMainView();	
				Globals.It.ShowSuccess(data.message);
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.BuyItem;
		}
	}
}