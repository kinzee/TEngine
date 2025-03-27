using TEngine;

namespace GameLogic
{
    public class LoginSystem:Singleton<LoginSystem>
    {
        protected override void OnInit()
        {
            base.OnInit();
            GameEvent.AddEventListener(ILoginUI_Event.ShowLoginUI, OnShowLoginUI);
            GameEvent.AddEventListener(ILoginUI_Event.CloseLoginUI, OnCloseLoginUI);
        }

        protected override void OnRelease()
        {
            
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