using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TEngine;

namespace GameLogic
{
    [Window(UILayer.Tips)]
    class ConnectNetUI : UIWindow
    {
        #region 脚本工具生成的代码
        private Text _text;
        protected override void ScriptGenerator()
        {
            _text = FindChildComponent<Text>("m_text");
        }
        #endregion
        
    }
}