using System;
using System.Collections.Generic;
using Services.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace Popups.ChoosePuzzle
{
    public class ChoosePuzzleView : PopupView, IChoosePuzzleView
    {
        /// должны были бы создаваться динамически в зависимости от количества вариантов
        /// в качестве примера сделано так
        [SerializeField] private List<Button> ChooseButtons;

        public event Action<int> OnPuzzleClick;

        public void SetPuzzleSprite(int index, Sprite sprite) => ChooseButtons[index].image.sprite = sprite;
        
        public override void Subscribe()
        {
            for (var i = 0; i < ChooseButtons.Count; i++)
            {
                int index = i;
                ChooseButtons[i].onClick.AddListener(() => OnPuzzleClick?.Invoke(index));
            }
        }

        public override void Unsubscribe()
        {
            foreach (Button button in ChooseButtons)
            {
                button.onClick.RemoveAllListeners();
            }
        }
    }
}