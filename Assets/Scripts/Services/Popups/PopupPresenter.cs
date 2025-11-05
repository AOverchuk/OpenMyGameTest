using System;
using Cysharp.Threading.Tasks;

namespace Services.Popups
{
    public abstract class PopupPresenter<TView> : IPopupPresenter where TView : IPopupView
    {
        protected TView View;
        
        protected PopupPresenter(TView view) => View = view;

        public event Func<UniTask> OnClosed;

        public virtual async UniTask Show()
        {
            await View.Show();
            Subscribe();
        }

        public virtual async UniTask Hide()
        {
            await View.Hide();
            Unsubscribe();
        }

        protected virtual void Subscribe()
        {
            View.Subscribe();
            View.OnCloseRequested += HandleCloseRequest;
        }

        protected virtual void Unsubscribe()
        {
            View.Unsubscribe();
            View.OnCloseRequested -= HandleCloseRequest;
        }

        private void HandleCloseRequest() => OnClosed?.Invoke();
    }
}