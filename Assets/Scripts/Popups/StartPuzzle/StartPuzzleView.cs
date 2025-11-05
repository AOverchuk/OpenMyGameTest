using System;
using System.Collections.Generic;
using Services.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popups.StartPuzzle
{
    public class StartPuzzleView : PopupView, IStartPuzzleView
    {
        /// должно были бы создаваться динамически в зависимости от количества вариантов
        /// в качестве примера сделано так
        [SerializeField] private List<Button> ChangeDetailsCountButtons;
        [SerializeField] private List<TextMeshProUGUI> ChangeDetailsCountTexts;
        [SerializeField] private Button GoToPuzzleButton;
        [SerializeField] private TextMeshProUGUI GoToPuzzleButtonText;
        [SerializeField] private Button CloseButton;
        [SerializeField] private Image PuzzleImage;
        [SerializeField] private Color DetailsButtonChosenBgColor;

        public event Action<int> OnChangeDetailsClick;
        public event Action OnGoToPuzzleClick;

        public void SetDetailsTexts(int index, string text) => ChangeDetailsCountTexts[index].text = text;
        
        public override void Subscribe()
        {
            for (var i = 0; i < ChangeDetailsCountButtons.Count; i++)
            {
                int index = i;
                ChangeDetailsCountButtons[i].onClick.AddListener(() => OnChangeDetailsClick?.Invoke(index));
            }
            
            GoToPuzzleButton.onClick.AddListener(() => OnGoToPuzzleClick?.Invoke());
            CloseButton.onClick.AddListener(Close);
        }

        public override void Unsubscribe()
        {
            foreach (Button button in ChangeDetailsCountButtons)
            {
                button.onClick.RemoveAllListeners();
            }
            
            GoToPuzzleButton.onClick.RemoveAllListeners();
            CloseButton.onClick.RemoveAllListeners();
        }

        //сетку рисовать не стал как в игре, т.к. глоьально на архитектуру не влияет
        public void SetDetailsButtonBgColor(int index)
        {
            for (var i = 0; i < ChangeDetailsCountButtons.Count; i++)
            {
                ChangeDetailsCountButtons[i].image.color = i == index ? DetailsButtonChosenBgColor : Color.white;
            }
        }
        
        public void SetPriceText(string text) => GoToPuzzleButtonText.text = text;
        
        public void SetPuzzleSprite(Sprite sprite) => PuzzleImage.sprite = sprite;
    }
}