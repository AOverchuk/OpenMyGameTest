using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services.Popups;
using Services.Puzzles;
using UnityEngine;

namespace Popups.StartPuzzle
{
    public class StartPuzzlePresenter : PopupPresenter<IStartPuzzleView>
    {
        private readonly PuzzleModel _model;
        private readonly PuzzlesService _puzzlesService;

        public StartPuzzlePresenter(IStartPuzzleView view, PuzzleModel model, PuzzlesService puzzlesService) : base(view)
        {
            View = view;
            _model = model;
            _puzzlesService = puzzlesService;
        }
        
        public override UniTask Show()
        {
            SetDetailsTexts();
            View.SetDetailsButtonBgColor(_model.CurrentDetailsCount);
            View.SetPuzzleSprite(_puzzlesService.GetPuzzleSprite(_model.CurrentPuzzle));
            View.SetPriceText(_puzzlesService.GetPuzzlePriceType(_model.CurrentPuzzle).ToString());
            return base.Show();
        }
        
        protected override void Subscribe()
        {
            base.Subscribe();
            View.OnChangeDetailsClick += OnChangeDetailsClick;
            View.OnGoToPuzzleClick += HandleGoToPuzzleClick;
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            View.OnChangeDetailsClick -= OnChangeDetailsClick;
            View.OnGoToPuzzleClick -= HandleGoToPuzzleClick;
        }

        private void SetDetailsTexts()
        {
            List<Puzzle> list = _puzzlesService.GetPuzzles();

            for (var index = 0; index < list.Count; index++)
            {
                Puzzle puzzle = list[index];
                View.SetDetailsTexts(index, puzzle.GetDetailsCount(index).ToString());
            }
        }

        private void OnChangeDetailsClick(int puzzleIndex)
        {
            _model.ChangeCurrentDetailsCount(puzzleIndex);
            View.SetDetailsButtonBgColor(puzzleIndex);
        }

        //такое обращение к строкам в райнтайм коде может быть не очень в плане памяти, но использую для демонстрации
        private void HandleGoToPuzzleClick() =>
            Debug.Log($"Загрузить пазл {_model.CurrentPuzzle} с количеством деталей " +
                      $"{_puzzlesService.GetDetailsCount(_model.CurrentPuzzle, _model.CurrentDetailsCount)} " +
                      $"с типом оплаты {_puzzlesService.GetPuzzlePriceType(_model.CurrentPuzzle)}");
    }
}