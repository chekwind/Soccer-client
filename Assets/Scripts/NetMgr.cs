﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetMgr : MonoBehaviour {

	public string sIP="127.0.0.1";
	public int iPort=11009;

	private XTcpClient m_Client;
	private System.Action m_ConnectSuccessCallBack;
	private bool m_bWarnLostConnect;
	void Awake(){
		_init ();
	}

	void _init(){
		m_Client = new XTcpClient ();
		m_Client.OnConnected += HandleM_ClientOnConnected;
		m_Client.OnDisconnected += HandleM_ClientOnDisconnected;
		m_Client.OnError += HandleM_ClientOnError;
	}
	void HandleM_ClientOnError(object sender,DSCClientErrorEventArgs e)
	{
		Debug.LogWarning ("::OnError");
		Connect ();
	}
	void HandleM_ClientOnDisconnected(object sender,DSCClientConnectedEventArgs e)
	{
		Debug.LogWarning ("::OnDisconnected");
	}
	void HandleM_ClientOnConnected(object sender,DSCClientConnectedEventArgs e)
	{
		Debug.LogWarning ("::OnConnected");
		if (Connected) {
			if(m_ConnectSuccessCallBack!=null){
				m_ConnectSuccessCallBack();
				m_ConnectSuccessCallBack=null;
			}
		}
		else{
			m_bWarnLostConnect=true;
		}
	}
	void _ShowLostConnect(){
		Globals.It.HideWaiting();
		Globals.It.ShowWarn (2, 5, null);
		Invoke ("RoleLogin", 5);
	}
	void FixedUpdate(){
		if (m_Client != null && m_Client.Connected) {
			Globals.It.ProcessMsg (m_Client.Loop ());
		}
		if (m_bWarnLostConnect) {
			m_bWarnLostConnect = false;
			_ShowLostConnect ();
		}
	}
	public void RoleLogin(){
		System.Action sendMsg = () => {
			Data_RoleEnterGame mode = new Data_RoleEnterGame (){userId=Globals.It.MainGamer.proMain.iUserID};
			Globals.It.SendMsg (mode, Const_ICommand.RoleEnterGame);
		};
		Globals.It.ShowWaiting();
		if (!Globals.It.Connected) {
			Globals.It.Connect(sendMsg);
			CancelInvoke();
		}
		else {
			sendMsg();
			CancelInvoke();
		}
	}
	public void ReInit(){
		_init ();
	}
	public void Connect()
	{
		m_Client.Connect (sIP, iPort);
	}
	public void Connect(System.Action callback)
	{
		m_ConnectSuccessCallBack = callback;
		m_Client.Connect (sIP, iPort);
	}
	public void Send(byte[] buffer)
	{
		if (buffer != null && Connected) {
			m_Client.Send(buffer);
		}
	}
	public void Close()
	{
		if (Connected) {
			m_Client.Close();
		}
	}
	public bool Connected
	{
		get{
			return m_Client!=null && m_Client.Connected;
		}
	}

}
