using UnityEngine;
using System.Collections;

public class StoreInfoProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_StoreInfo_R data = Globals.ToObject<Data_StoreInfo_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.MainGamer.proMain.SetStoreItemList(data.data);
				Globals.It.ShowStoreView();
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}else{
			Globals.It.NetManager.RoleLogin();
		}
	}
	
	public int iCommand{
		get{
			return Const_ICommand.StoreInfo;
		}
	}
}