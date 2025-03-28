using System;
using TEngine;
using UnityEngine;

namespace GameLogic.UI
{
    public class UIController : MonoBehaviour
    {
        private void Awake()
        {
            GameEvent.AddEventListener(ILoginUI_Event.ShowLoginUI, OnShowLoginUI);
            GameEvent.AddEventListener(ILoginUI_Event.CloseLoginUI, OnCloseLoginUI);
            GameEvent.AddEventListener(INetConnectUI_Event.ShowConnectUI, OnShowConnectUI);
            GameEvent.AddEventListener(INetConnectUI_Event.CloseConnectUI, OnCloseConnectUI);
        }
        
        private void OnDestroy()
        {
            GameEvent.RemoveEventListener(ILoginUI_Event.ShowLoginUI, OnShowLoginUI);
            GameEvent.RemoveEventListener(ILoginUI_Event.CloseLoginUI, OnCloseLoginUI);
            GameEvent.RemoveEventListener(INetConnectUI_Event.ShowConnectUI, OnShowConnectUI);
            GameEvent.RemoveEventListener(INetConnectUI_Event.CloseConnectUI, OnCloseConnectUI);
        }
        
        protected void OnShowConnectUI()
        {
            GameModule.UI.ShowUIAsync<ConnectNetUI>();
        }
        
        protected void OnCloseConnectUI()
        {
            GameModule.UI.CloseUI<ConnectNetUI>();
        }
        
        protected void OnShowLoginUI()
        {
            GameModule.UI.ShowUIAsync<LoginUI>();
        }
        
        public void OnCloseLoginUI()
        {
            GameModule.UI.CloseUI<LoginUI>();
        }
    }
}