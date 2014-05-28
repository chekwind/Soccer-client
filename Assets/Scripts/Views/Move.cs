using UnityEngine;
using System.Collections;

public class Move:MonoBehaviour{

	public UILabel labellv;

	bool isTouch = false;
	bool isRight = false;
	bool isLeft = false;
	bool isOnDrag = false;
	void OnDrag(Vector2 delta){
		if (!isTouch) {
			if(delta.x>0.5){
				isRight=true;
				isOnDrag=true;
			}else if(delta.x<-0.5){
				isLeft=true;
				isOnDrag=true;
			}
			isTouch=true;
		}
	}
	void OnPress(){
		if (Globe.currentindex < Globe.listcount && isLeft) {
			Globe.currentindex++;
		}
		if (Globe.currentindex >0 && isRight) {
			Globe.currentindex--;
		}
		isTouch = false;
		isLeft = false;
		isRight = false;
	}

	void Update(){
		switch (Globe.currentindex) {
		case 0:labellv.text="LV1-LV20";break;
		case 1:labellv.text="LV21-LV30";break;
		case 2:labellv.text="LV31-LV40";break;
		case 3:labellv.text="LV41-LV50";break;
		case 4:labellv.text="LV51-LV60";break;
		}
		Globe.panel.transform.localPosition = Vector3.Lerp (Globe.panel.transform.localPosition, new Vector3 (-(Globe.currentindex * Globe.offset), 0, 0), Time.deltaTime * 5);
	}

	void OnClick(){
		if (!isOnDrag) {

		}else{
			isOnDrag=false;
		}
	}

}