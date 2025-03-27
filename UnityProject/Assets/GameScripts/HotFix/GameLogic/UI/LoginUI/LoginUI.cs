using Cysharp.Threading.Tasks;
using Fantasy;
using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class LoginUI : UIWindow
    {
        #region 脚本工具生成的代码
        private InputField _inputAccount;
        private InputField _inputPassword;
        private Button _btnLogin;
        protected override void ScriptGenerator()
        {
            _inputAccount = FindChildComponent<InputField>("m_inputAccount");
            _inputPassword = FindChildComponent<InputField>("m_inputPassword");
            _btnLogin = FindChildComponent<Button>("m_btnLogin");
            _btnLogin.onClick.AddListener(UniTask.UnityAction(OnClickLoginBtn));
        }
        #endregion

        #region 事件
        private async UniTaskVoid OnClickLoginBtn()
        {
            GameModule.Net.Send(new C2G_TestMessage()
            {
                Tag = "Login"
            });
        }
        #endregion

        
    }
}


