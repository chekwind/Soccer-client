using UnityEngine;
using System.Collections;

public class RoleEnterGameProtocol:IProtocol{

	public void Process(Message_Body info){
		Data_RoleEnterGame_R data = Globals.ToObject<Data_RoleEnterGame_R> (info.body);
		if (data != null) {
			if(data.result){
				if (!data.data.hasRole) {
					//					Globals.It.ShowKaiChangGifView();
					Globals.It.HideWaiting();
				}
				else {
					Globals.It.MainGamer.proMain.SetRoleEnterGame(data.data);
					if(Globals.It.MainGamer.proMain.lPlayerList.Count==0){
						Globals.It.RefreshPlayerList();
					}else{
						Globals.It.ShowMainView();
					}
				}
			}
			else{
				Globals.It.HideWaiting();
				Globals.It.ShowWarn(Const_ITextID.Msg_Tishi,data.message,null);
			}
		}
	}

	public int iCommand{
		get{
			return Const_ICommand.RoleEnterGame;
		}
	}
}