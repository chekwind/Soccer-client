using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Task:MonoBehaviour{

	public UILabel labelpurpose, labelreward,labelnum1,labelnum2,labelnum3;
	public UISprite spriteitem1, spriteitem2, spriteitem3,spritetype;
	private string reward;
	private int taskgo;

	public void SetData(Data_GetTask_R.tasks task){
		spriteitem1.gameObject.SetActive (false);
		spriteitem2.gameObject.SetActive (false);
		spriteitem3.gameObject.SetActive (false);
		labelnum1.text = labelnum2.text = labelnum3.text = "";

		if (task.expprice != 0) {
			reward=task.expprice+"经验";
		}
		if (task.trainpointprice != 0) {
			reward+=","+task.trainpointprice+"训练点";
		}
		if (task.gamecoinprice != 0) {
			reward+=","+task.gamecoinprice+"银币";
		}
		labelpurpose.text = task.purpose;
		labelreward.text = reward;
		for (int i=0; i<task.items.Length; i++) {
			if(i==0){
				spriteitem1.gameObject.SetActive (true);
				spriteitem1.spriteName=task.items[i].itemid.ToString();
				labelnum1.text=task.items[i].stack.ToString();
			}
		}
		if (task.tasktype == 1) {
				spritetype.spriteName = "Task_main";
		} else {
				spritetype.spriteName = "Task_bruch";
		}
		taskgo = task.taskgo;
	}
	public void onClick(){
		switch (taskgo) {
		case 1:
			Data_GetTrainMatch data = new Data_GetTrainMatch (){
				characterId=Globals.It.MainGamer.proMain.iCharacterId,
				leagueindex=2,
			};
			Globals.It.SendMsg (data, Const_ICommand.GetTrainMatch);
			break;
		case 2:break;
		}
		Globals.It.DestoryTaskView ();
	}
}