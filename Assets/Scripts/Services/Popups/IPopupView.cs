using System;
using Cysharp.Threading.Tasks;

namespace Services.Popups
{
    public interface IPopupView
    {
        UniTask Show();
        UniTask Hide();
        void Subscribe();
        void Unsubscribe();
        event Action OnCloseRequested;
    }
}