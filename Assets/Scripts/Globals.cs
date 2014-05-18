#define USER_LOCAL_RESOURCES
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour {

	public static readonly string VERSION="V1.0";
	public static readonly int SERVERVERSION=0;
	public static readonly string BUNDLEVERSION="2014033116";

	public static Globals It;

	public bool bTestView;
	public GameObject waitingView;
	public Transform waitingParentT;
	public kLanguage klanguage;
	public string urlResource;
	public AudioClip bgAudio;

	private Transform m_CacheTran;
	private string m_sBundlePath;
	private bool m_bUseLocalResources;
	private GameObject m_WaitingView;
	private MessageBoxView m_MessageBoxView;
	private SuccessView m_SuccessView;
	private InputBoxView m_InputBoxView;
	private DengluView m_DengluView;
	private MainView m_MainView;
	private GamerInfoView m_GamerinfoView;
	private PlayerView m_PlayerView;
	private LineUpView  m_LineUpView;
	private RotateView m_RotateView;
	private TrainingView m_TrainingView;
	private TacticsView m_TacticsView;
	private PlayerInnerView m_PlayerInnerView;
	private PlayerSignView m_PlayerSignView;
	private BagView m_BagView;
	private StoreView m_StoreView;
	private BuyView m_BuyView;

	public bool bUseLocalResources{ get { return m_bUseLocalResources; } }
	public string sBundlePath{ get { return m_sBundlePath; } }

	private NetMgr m_NetMgr;
	private ProtocolMgr m_ProtocolMgr;
	private Gamer m_MainGamer;
	private LanguageMgr m_LanguageMgr;
	private BundleMgr m_BundleMgr;

	public NetMgr NetManager { get { return m_NetMgr; } }
	public ProtocolMgr ProtocolMgr{ get { return m_ProtocolMgr; } }
	public Gamer MainGamer { get { return m_MainGamer; } }
	public LanguageMgr LanguageMgr{ get { return m_LanguageMgr; } }
	public BundleMgr BundleMgr{ get { return m_BundleMgr; } }


	public bool Connected{
		get{
			return NetManager.Connected;
		}
	}
	#region sys
	void Awake(){
		It = this;
		m_CacheTran = transform;
		m_bUseLocalResources = true;
	}

	void Start(){
		switch (klanguage) {
		case kLanguage.Chinese:
		{
			m_sBundlePath="Chinese";
			break;
		}
		}
		StartCoroutine ("_DoStart");
	}

	void OnDestory(){
		Debug.Log ("destory");
		NetManager.Close ();
	}

	void _LoadLinkBeforeLoad(){
		m_NetMgr = _CreateLink<NetMgr> ();
		m_ProtocolMgr = _CreateLink<ProtocolMgr> ();
		m_BundleMgr = _CreateLink<BundleMgr> ();
		m_MainGamer = _CreateLink<Gamer> ();
	}
	void _LoadLinkAfterLoad(){
		m_LanguageMgr = _CreateLink<LanguageMgr> ();
	}

	T _CreateLink<T>() where T:Component{
		T link = this.GetComponentInChildren<T> ();
		if (link == null) {
			GameObject linkObject=new GameObject(typeof(T).Name);
			link=linkObject.AddComponent<T>();
			linkObject.transform.parent=m_CacheTran;
		}
		return link;
	}

	IEnumerator _DoStart(){
		yield return 0;
		_LoadLinkBeforeLoad ();
		BundleMgr.DoInit ();
		_LoadLinkAfterLoad ();
		if (!bTestView) {
			StartCoroutine("_CreateLoginView");
		}
	}

	IEnumerator _CreateLoginView(){
		yield return null;
		System.Action<Object> handler=(asset)=>{
			if(asset!=null){
				GameObject dengluObject=(GameObject)GameObject.Instantiate(asset);
				m_DengluView=dengluObject.GetComponent<DengluView>();
				NGUIUtility.SetParent(waitingParentT,dengluObject.transform);

				AudioManager.PlayLoopSound(bgAudio);
			}
			HideWaiting();
		};
		ShowWaiting ();
		StartCoroutine (BundleMgr.CreateObject (kResource.View, "DengluView", "DengluView", handler));
	}
	#endregion

	#region ui
	public void ShowWaiting(){
		StartCoroutine ("_ShowWaiting");
	}
	public void ShowWaitingImmediate(){
		StartCoroutine ("_ShowWaitingImmediate");
	}
	public void HideWaiting(){
		StopCoroutine ("_ShowWaiting");
		StopCoroutine ("_ShowWaitingImmediate");
		if (m_WaitingView != null) {
			GameObject.DestroyObject(m_WaitingView);
		}
	}
	private IEnumerator _ShowWaitingImmediate(){
		yield return 0;
		{
			if(m_WaitingView==null && waitingView!=null){
				System.Action<Object> handler = (asset) =>{
					if(asset!=null){
						m_WaitingView=(GameObject)GameObject.Instantiate(asset);
						NGUIUtility.SetParent(waitingParentT,m_WaitingView.transform);
					}
				};

				StartCoroutine(BundleMgr.CreateObject(kResource.Common,"WaitingView","WaitingView",handler));
			}
		}
	}
	private IEnumerator _ShowWaiting(){
		yield return new WaitForSeconds (1.0f);
		{
			if(m_WaitingView==null && waitingView!=null){
				System.Action<Object> handler=(asset) =>{
					if(asset!=null){
						m_WaitingView=(GameObject)GameObject.Instantiate(asset);
						NGUIUtility.SetParent(waitingParentT,m_WaitingView.transform);
					}
				};
				StartCoroutine(BundleMgr.CreateObject(kResource.Common,"WaitingView","WaitingView",handler));
			}
		}
	}

	public void ShowWarn(int iTitle,int iMsg,System.Action callback){
		string strMsg = LanguageMgr.GetString (iMsg);
		ShowWarn (iTitle, strMsg, callback);
	}
	public void ShowWarn(int iTitle,string strMsg,System.Action callback){
		string sTitle = LanguageMgr.GetString (iTitle);
		Debug.LogError (strMsg);
		if (m_MessageBoxView == null) {
			System.Action<Object> handler=(asset)=>{
				if(asset!=null){
					GameObject objMsgBox=(GameObject)GameObject.Instantiate(asset);
					m_MessageBoxView=objMsgBox.GetComponent<MessageBoxView>();
					NGUIUtility.SetParent(waitingParentT,objMsgBox.transform);
					m_MessageBoxView.show(sTitle,strMsg,callback);
				}
			};
			StartCoroutine(BundleMgr.CreateObject(kResource.View,"MessageBoxView","MessageBoxView",handler));
		}
	}
	public void HideWarn(){
		if (m_MessageBoxView != null) {
			GameObject.DestroyObject(m_MessageBoxView.gameObject);
			m_MessageBoxView=null;
		}
	}
	public void ShowSuccess(string strMsg){
		if (m_SuccessView == null) {
			System.Action<Object> handler=(asset)=>{
				if(asset!=null){
					GameObject SuccessBox=(GameObject)GameObject.Instantiate(asset);
					m_SuccessView=SuccessBox.GetComponent<SuccessView>();
					NGUIUtility.SetParent(waitingParentT,SuccessBox.transform);
					m_SuccessView.show(strMsg);
				}
			};
			StartCoroutine(BundleMgr.CreateObject(kResource.View,"SuccessView","SuccessView",handler));
		}
	}
	public void HideSuccess(){
		if (m_SuccessView != null) {
			GameObject.DestroyObject(m_SuccessView.gameObject);
			m_SuccessView=null;
		}
	}
	public void ShowInput(System.Action<string> callback){
		if (m_InputBoxView == null) {
			System.Action<Object> handler=(asset)=>{
				if(asset!=null){
					GameObject objInputBox=(GameObject)GameObject.Instantiate(asset);
					m_InputBoxView=objInputBox.GetComponent<InputBoxView>();
					NGUIUtility.SetParent(waitingParentT,objInputBox.transform);
					m_InputBoxView.onShow(callback);
				}
			};
			StartCoroutine(BundleMgr.CreateObject(kResource.View,"InputBoxView","InputBoxView",handler));
		}
	}
	public void HideInput(){
		if (m_InputBoxView != null) {
			GameObject.DestroyObject(m_InputBoxView.gameObject);
			m_InputBoxView=null;
		}
	}

	#endregion

	#region net
	public void Connect(System.Action callback){
		NetManager.Connect (callback);
	}
	public void ProcessMsg(MessageData info){
		if (info == null) return;
		ProtocolMgr.Process (info.body);
	}
	public void SendMsg<T>(T data,int iCommand) where T:Data_Base{
		string sJson = LitJson.JsonMapper.ToJson (data);
		Debug.LogWarning (string.Format ("::OnSend:{0},{1}", iCommand, sJson));
		byte[] sendBytes = MessageParse.Parse (SERVERVERSION, iCommand, sJson);
		Globals.It.NetManager.Send (sendBytes);
	}


	#endregion


	#region view 
	public void DestoryDengluView(){//销毁登陆视图
		if (m_DengluView != null) {
			m_DengluView.save();
			GameObject.DestroyImmediate(m_DengluView.gameObject,true);
			m_DengluView=null;
		}
	}
	public void ShowEnterGameView(){//创建进入游戏视图
		ShowWaiting ();
		Data_RoleEnterGame mode = new Data_RoleEnterGame (){characterId=MainGamer.proMain.iCharacterId};
		Globals.It.SendMsg (mode, Const_ICommand.RoleEnterGame);
		Globals.It.SendMsg(mode,Const_ICommand.GetPlayerList);
	}
	public void ShowMainView(){//创建主界面视图
		if (m_MainView == null) {
			System.Action<Object> handler = (asset) => {
					if (asset != null) {
							GameObject mainView = (GameObject)GameObject.Instantiate (asset);
							m_MainView = mainView.GetComponent<MainView>();
							NGUIUtility.SetParent (waitingParentT, mainView.transform);
							Globals.It.HideWaiting();
					}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "MainView", "MainView", handler));
		} 
		else {
			if(MainGamer.proMain.bNeedRefresh){//需要更新
				ShowWaiting();
				Data_GamerStat data=new Data_GamerStat(){characterId=MainGamer.proMain.iCharacterId};
				Globals.It.SendMsg(data,Const_ICommand.GamerStat);			
			}else{
				m_MainView.gameObject.SetActive(true);
				m_MainView.RefreshGamerStat();
				if(m_RotateView!=null){
					m_RotateView.Refresh();
				}
				if(m_TrainingView!=null){
					m_TrainingView.Refresh();
				}
				if(m_StoreView!=null){
						m_StoreView.Refresh();
				}
				Globals.It.HideWaiting();
			}
		}
	}
	public void RefreshPlayerList(){
		Data_GamerStat data=new Data_GamerStat(){characterId=MainGamer.proMain.iCharacterId};
		Globals.It.SendMsg(data,Const_ICommand.GetPlayerList);
	}
	public void ShowGamerInfoView(){//创建球队信息视图
		if (m_GamerinfoView == null) {
				System.Action<Object> handler = (asset) => {
						if (asset != null) {
								GameObject gamerInfoObject = (GameObject)GameObject.Instantiate (asset);
								m_GamerinfoView = gamerInfoObject.GetComponent<GamerInfoView> ();
								m_GamerinfoView.show ();
								NGUIUtility.SetParent (waitingParentT, gamerInfoObject.transform);
						}
				};
				StartCoroutine (BundleMgr.CreateObject (kResource.View, "GamerInfoView", "GamerInfoView", handler));
		}
	}
	public void DestoryGamerInfoView(){//销毁球队信息视图
		if (m_GamerinfoView != null) {
			GameObject.DestroyImmediate(m_GamerinfoView.gameObject,true);
			m_GamerinfoView=null;
		}
	}
	#region playerinfo
	public void ShowPlayerInfo(PlayerJson json,int sign){//创建球员信息视图
		if (m_PlayerView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject playerObject = (GameObject)GameObject.Instantiate (asset);
					m_PlayerView = playerObject.GetComponent<PlayerView> ();
					m_PlayerView.show (json,sign);
					NGUIUtility.SetParent (waitingParentT, playerObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "PlayerView", "PlayerView", handler));
		}
	}
	public void RefreshPlayerView(){//刷新球员信息
		m_PlayerView.Refresh();
	}
	public void DestoryPlayerView(){//销毁球员信息视图
		if (m_PlayerView != null) {
			GameObject.DestroyImmediate(m_PlayerView.gameObject,true);
			m_PlayerView=null;
		}
	}
	#endregion
	#region lineup
	public void ShowLineUp(){//创建阵容页视图
		if (m_LineUpView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject lineupObject = (GameObject)GameObject.Instantiate (asset);
					m_LineUpView = lineupObject.GetComponent<LineUpView> ();
					m_LineUpView.show ();
					NGUIUtility.SetParent (waitingParentT, lineupObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "LineUpView", "LineUpView", handler));
		}
	}
	public void DestoryLineUpView(){//销毁阵容页视图
		if (m_LineUpView != null) {
			GameObject.DestroyImmediate(m_LineUpView.gameObject,true);
			m_LineUpView=null;
		}
	}
	#endregion
	#region rotate
	public void ShowRotateView(){//创建轮换页视图
		if (m_RotateView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject rotateObject = (GameObject)GameObject.Instantiate (asset);
					m_RotateView = rotateObject.GetComponent<RotateView> ();
					m_RotateView.show ();
					NGUIUtility.SetParent (waitingParentT, rotateObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "RotateView", "RotateView", handler));
		}
	}
	public void Rotate(int mainplayer,int benchplayer){//球员轮换
		if(mainplayer!=0 && benchplayer!=0){
			m_RotateView.Rotate (mainplayer,benchplayer);
		}else{
			m_RotateView.Refresh();
		}
	}
	public void DestoryRotateView(){//销毁轮换页视图
		if (m_RotateView != null) {
			GameObject.DestroyImmediate(m_RotateView.gameObject,true);
			m_RotateView=null;
		}
	}
	#endregion
	#region training
	public void ShowTrainingView(){//创建训练页视图
		if (m_TrainingView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject trainingObject = (GameObject)GameObject.Instantiate (asset);
					m_TrainingView = trainingObject.GetComponent<TrainingView> ();
					m_TrainingView.show ();
					NGUIUtility.SetParent (waitingParentT, trainingObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "TrainingView", "TrainingView", handler));
		}
	}
	public void DestoryTrainingView(){//销毁训练页视图
		if (m_TrainingView != null) {
			GameObject.DestroyImmediate(m_TrainingView.gameObject,true);
			m_TrainingView=null;
		}
	}
	#endregion
	#region tactics
	public void ShowTacticsView(){//创建战术页视图
		if (m_TacticsView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject tacticsObject = (GameObject)GameObject.Instantiate (asset);
					m_TacticsView = tacticsObject.GetComponent<TacticsView> ();
					m_TacticsView.show ();
					NGUIUtility.SetParent (waitingParentT, tacticsObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "TacticsView", "TacticsView", handler));
		}
	}
	public void DestoryTacticsView(){//销毁战术页视图
		if (m_TacticsView != null) {
			GameObject.DestroyImmediate(m_TacticsView.gameObject,true);
			m_TacticsView=null;
		}
	}
	#endregion
	#region playerinner
	public void ShowPlayerInnerView(Data_PlayerInner_R.Data data,int leagueindex){//创建抽球员视图
		if (m_PlayerInnerView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject playerinnerObject = (GameObject)GameObject.Instantiate (asset);
					m_PlayerInnerView = playerinnerObject.GetComponent<PlayerInnerView> ();
					m_PlayerInnerView.show (data,leagueindex);
					NGUIUtility.SetParent (waitingParentT, playerinnerObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "PlayerInnerView", "PlayerInnerView", handler));
		}else{
			m_PlayerInnerView.ReShow(data);
		}
	}
	public void RefreshPlayerInnerView(){//更新抽球员信息
		if(m_PlayerInnerView!=null){
			m_PlayerInnerView.Refresh();
		}
	}
	public void DestoryPlayerInnerView(){//销毁抽球员视图
		if (m_PlayerInnerView != null) {
			GameObject.DestroyImmediate(m_PlayerInnerView.gameObject,true);
			m_PlayerInnerView=null;
		}
	}
	#endregion
	#region playersign
	public void ShowPlayerSignView(Data_PickPlayer_R.player data,int source){//创建抽球员视图
		if (m_PlayerSignView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject playersignObject = (GameObject)GameObject.Instantiate (asset);
					m_PlayerSignView = playersignObject.GetComponent<PlayerSignView> ();
					m_PlayerSignView.show (data,source);
					NGUIUtility.SetParent (waitingParentT, playersignObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "PlayerSignView", "PlayerSignView", handler));
		}
	}
	public void DestoryPlayerSignView(){//销毁抽球员视图
		if (m_PlayerSignView != null) {
			GameObject.DestroyImmediate(m_PlayerSignView.gameObject,true);
			m_PlayerSignView=null;
		}
	}
	#endregion
	#region bag
	public void ShowBagView(){//创建背包视图
		if (m_BagView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject bagObject = (GameObject)GameObject.Instantiate (asset);
					m_BagView = bagObject.GetComponent<BagView> ();
					m_BagView.show ();
					NGUIUtility.SetParent (waitingParentT, bagObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "BagView", "BagView", handler));
		}else{
			m_BagView.reshow();
		}
	}
	public void DestoryBagView(){//销毁背包视图
		if (m_BagView != null) {
			GameObject.DestroyImmediate(m_BagView.gameObject,true);
			m_BagView=null;
		}
	}
	public void SetBagRight(ItemJson json){
		m_BagView.SetBagRight (json);
	}
	#endregion
	#region store
	public void ShowStoreView(){//创建商店视图
		if (m_StoreView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject storeObject = (GameObject)GameObject.Instantiate (asset);
					m_StoreView = storeObject.GetComponent<StoreView> ();
					m_StoreView.show ();
					NGUIUtility.SetParent (waitingParentT, storeObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "StoreView", "StoreView", handler));
		}

	}
	public void DestoryStoreView(){//销毁商店视图
		if (m_StoreView != null) {
			GameObject.DestroyImmediate(m_StoreView.gameObject,true);
			m_StoreView=null;
		}
	}
	#endregion
	#region buy
	public void ShowBuyView(ItemJson itemjson){//创建购买视图
		if (m_BuyView == null) {
			System.Action<Object> handler = (asset) => {
				if (asset != null) {
					GameObject buyObject = (GameObject)GameObject.Instantiate (asset);
					m_BuyView = buyObject.GetComponent<BuyView> ();
					m_BuyView.show (itemjson);
					NGUIUtility.SetParent (waitingParentT, buyObject.transform);
				}
			};
			StartCoroutine (BundleMgr.CreateObject (kResource.View, "BuyView", "BuyView", handler));
		}
	}
	public void DestoryBuyView(){//销毁购买视图
		if (m_BuyView != null) {
			GameObject.DestroyImmediate(m_BuyView.gameObject,true);
			m_BuyView=null;
		}
	}
	#endregion
	#endregion

	public static T ToObject<T>(byte[] buffer) where T:Data_Base{
		if (buffer != null && buffer.Length > 0) {
			string sJson=System.Text.Encoding.UTF8.GetString(buffer);
			T data=LitJson.JsonMapper.ToObject<T>(sJson);
			return data;
		}
		return default(T);
	}
}

public enum kLanguage{
	Chinese=0,
	English,
}

public enum kResource{
	Config,
	View,
	Common,
	Font,
	Effect,
}

public enum kLoadResult{
	None=0,
	SUCC,
	Load,
	Fail,
}