using System;
using Cysharp.Threading.Tasks;

namespace Services.Popups
{
    // привык окна называть Popup, использую тут тот же нейминг
    public interface IPopupPresenter
    {
        UniTask Show();
        UniTask Hide();
        event Func<UniTask> OnClosed;
    }
}