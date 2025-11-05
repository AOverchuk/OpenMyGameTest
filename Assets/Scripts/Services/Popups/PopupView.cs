using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.Popups
{
    public abstract class PopupView : MonoBehaviour, IPopupView
    {
        public event Action OnCloseRequested;

        public virtual async UniTask Show()
        {
            await UniTask.Delay(100); // симуляция задержки анимации
            gameObject.SetActive(true);
        }

        public virtual async UniTask Hide()
        {
            await UniTask.Delay(100);
            gameObject.SetActive(false);
            //постоянно уничтожать/создавать окна не очень, но не стал делать пул или выключение без уничтожение для простоты
            Destroy(gameObject);
        }

        public abstract void Subscribe();
        public abstract void Unsubscribe();
        
        protected void Close() => OnCloseRequested?.Invoke();
    }
}