using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TaskParent:MonoBehaviour
{
	public Task task;
	
	private Vector3[] taskPos={
		new Vector3(0,120,0),
		new Vector3(-80,60,0),

	};
	public Task[] Init (int iStart,int iEnd,Data_GetTask_R.Data tasklist){
		Task[] tasks=new Task[iEnd-iStart+1];
		for(int i=0;i<iEnd-iStart+1;i++){
			tasks[i]=(Task)GameObject.Instantiate (task);
			tasks[i].SetData (tasklist.tasks[iStart+i]);
			NGUIUtility.SetParent (transform, tasks[i].transform);
			tasks[i].transform.localPosition = taskPos [i];
		}
		return tasks;
	}
}

