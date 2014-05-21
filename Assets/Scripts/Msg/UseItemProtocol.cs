using UnityEngine;
using System.Collections;

public class UseItemProtocol:IProtocol{
	
	public void Process(Message_Body info){
		Data_UseItem_R data = Globals.ToObject<Data_UseItem_R> (info.body);
		if (data != null) {
			if(data.result){
				Globals.It.MainGamer.proMain.bNeedRefresh=true;
				Globals.It.ShowMainView();
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
			return Const_ICommand.UseItem;
		}
	}
}