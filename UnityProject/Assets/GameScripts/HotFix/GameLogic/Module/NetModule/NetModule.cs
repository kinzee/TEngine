using Cysharp.Threading.Tasks;
using Fantasy;
using Fantasy.Entitas;
using Fantasy.Helper;
using Fantasy.Network;
using Fantasy.Network.Interface;
using TEngine;
using Log = TEngine.Log;

namespace GameLogic
{
    public enum NetState
    {
        Init,
        Connect,
        Disconnect,
        Error,
    }

    /// <summary>
    /// 网络管理模块
    /// </summary>
    public sealed class NetModule : Singleton<NetModule>, IUpdate
    {
        public NetState State { get; private set; } = NetState.Init;
        private Session _session;
        private static Scene _scene;

        protected override void OnInit()
        {
            FantasyInitialize().Forget();
        }

        protected override void OnRelease()
        {
            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }
        }

        public void OnUpdate()
        {
        }

        public async UniTaskVoid FantasyInitialize()
        {
            await Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly, typeof(GameProtoEntry).Assembly);
            _scene = await Fantasy.Platform.Unity.Entry.CreateScene();
        }

        public async UniTask Connect(string address, bool reconnect = false)
        {
            Log.Info($"开始连接服务器：{address}");
            GameEvent.Get<INetConnectUI>().ShowConnectUI();
            await UniTask.WaitUntil(() => _scene != null);
            _session = _scene.Connect(address, NetworkProtocolType.TCP, OnConnectCompleted, OnConnectFailed, OnDisconnect, false, 3000);
        }
        
        public void DisConnect()
        {
            _session.Dispose();
        }

        public void Send(IMessage message)
        {
            _session.Send(message);
        }


        private void OnConnectCompleted()
        {
            Log.Info("连接服务器成功");
            _session.AddComponent<SessionHeartbeatComponent>().Start(3000);
            GameEvent.Get<INetConnectUI>().CloseConnectUI();
        }

        private void OnConnectFailed()
        {
            Log.Error("连接服务器失败");
            GameEvent.Get<INetConnectUI>().CloseConnectUI();
        }

        private void OnDisconnect()
        {
            Log.Info("与服务器断开连接");
        }
    }
}