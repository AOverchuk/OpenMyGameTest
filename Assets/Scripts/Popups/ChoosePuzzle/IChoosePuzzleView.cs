using System;
using Services.Popups;
using UnityEngine;

namespace Popups.ChoosePuzzle
{
    public interface IChoosePuzzleView : IPopupView
    {
        void SetPuzzleSprite(int index, Sprite sprite);
        event Action<int> OnPuzzleClick;
    }
}