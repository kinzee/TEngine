using TEngine;

namespace GameLogic
{
    [EventInterface(EEventGroup.GroupUI)]
    public interface INetConnectUI
    {
        void ShowConnectUI();
        void CloseConnectUI();
    }
}