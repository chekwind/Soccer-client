using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TaskView:MonoBehaviour{

	public UIGrid gridItemParent;
	public GameObject gridChildItem;
	public UIPanel taskPanel;
	private int iTaskCount;
	
	private List<Task> m_Tasks = new List<Task> ();
	
	public void show(Data_GetTask_R.Data tasks){
		
		iTaskCount = tasks.tasks.Length;
		int iObjectCount = iTaskCount / 2;
		int iend = iTaskCount % 2;
		if (iend != 0) {
			iObjectCount+=1;
		}
		int iPos = 0, iOffset = 0;
		for (; iPos<iObjectCount; iPos++) {
			GameObject gridItem = (GameObject)GameObject.Instantiate (gridChildItem);
			TaskParent itemParent = gridItem.GetComponent<TaskParent> ();
			if(iTaskCount>=(iPos+1)*2){
				m_Tasks.AddRange (itemParent.Init (iOffset,iOffset+1,tasks));
				iOffset+=2;
			}else{
				m_Tasks.AddRange (itemParent.Init (iOffset,iOffset+iend-1,tasks));
			}
			NGUIUtility.SetParent (gridItemParent.transform, gridItem.transform);
		}
		gridItemParent.Reposition ();

	}
	
	public void onClose(){
		Globals.It.DestoryTaskView ();
	}
}

