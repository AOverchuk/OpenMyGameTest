using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Services.Popups
{
    public class PopupsService
    {
        private PopupsFactory _popupsFactory;
        private readonly Stack<IPopupPresenter> _openedPopups = new();

        public void Init(PopupsFactory popupsFactory) => _popupsFactory = popupsFactory;

        public async UniTask ShowPopup(WindowType type)
        {
            IPopupPresenter presenter = _popupsFactory.CreatePresenter(type);
            await presenter.Show();
            presenter.OnClosed += ClosePopup;
            _openedPopups.Push(presenter);
        }

        private async UniTask ClosePopup()
        {
            IPopupPresenter currentPopupPresenter = _openedPopups.Pop();
            await currentPopupPresenter.Hide();
            currentPopupPresenter.OnClosed -= ClosePopup;
        }
    }
}
