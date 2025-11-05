using System;
using Services.Popups;
using UnityEngine;

namespace Popups.StartPuzzle
{
    public interface IStartPuzzleView : IPopupView
    {
        void SetDetailsTexts(int index, string text);
        void SetDetailsButtonBgColor(int index);
        void SetPuzzleSprite(Sprite sprite);
        void SetPriceText(string text);
        event Action<int> OnChangeDetailsClick;
        event Action OnGoToPuzzleClick;
    }
}