using UnityEngine;
using System.Collections;

public class GamerStat:MonoBehaviour{
	public UILabel labelLevel,labelGameCoin,labelCoin,labelRepute,labelPower,labelTrainPoint,labelName,labelExp;
	public UISlider expSlider;
	

	public void Refresh(){
		GamerPropertyMain proMain=Globals.It.MainGamer.proMain;
		labelLevel.text=proMain.iLevel.ToString();
		labelGameCoin.text = proMain.iGameCoin.ToString ();
		labelCoin.text = proMain.iCoin.ToString ();
		labelPower.text = proMain.iPower.ToString ();
		labelRepute.text = proMain.iRepute.ToString ();
		labelTrainPoint.text = proMain.iTrainPoint.ToString();
		labelName.text = proMain.sRoleName.ToString();
		labelExp.text = proMain.fExp.ToString () + "/" + proMain.fMaxExp.ToString ();
		expSlider.sliderValue = proMain.fExp / proMain.fMaxExp;
	}

	public void onClick(){
		GamerPropertyMain proMain=Globals.It.MainGamer.proMain;
		Globals.It.ShowGamerInfoView ();
	}
}