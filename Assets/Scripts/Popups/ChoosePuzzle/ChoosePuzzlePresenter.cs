using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services.Popups;
using Services.Puzzles;

namespace Popups.ChoosePuzzle
{
    public class ChoosePuzzlePresenter : PopupPresenter<IChoosePuzzleView>
    {
        private readonly PuzzleModel _model;
        private readonly PuzzlesService _puzzlesService;
        private readonly PopupsService _popupsService;

        public ChoosePuzzlePresenter(
            IChoosePuzzleView view, 
            PuzzleModel model, 
            PuzzlesService puzzlesService, 
            PopupsService popupsService) : base(view)
        {
            View = view;
            _model = model;
            _puzzlesService = puzzlesService;
            _popupsService = popupsService;
        }
        
        public override UniTask Show()
        {
            SetPuzzlesSprites();
            return base.Show();
        }
        
        protected override void Subscribe()
        {
            base.Subscribe();
            View.OnPuzzleClick += OnPuzzleClick;
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            View.OnPuzzleClick -= OnPuzzleClick;
        }

        private void SetPuzzlesSprites()
        {
            List<Puzzle> list = _puzzlesService.GetPuzzles();

            for (var index = 0; index < list.Count; index++)
            {
                Puzzle puzzle = list[index];
                View.SetPuzzleSprite(index, puzzle.GetSprite());
            }
        }

        private void OnPuzzleClick(int puzzleIndex)
        {
            _model.ChangeCurrentPuzzle(puzzleIndex);
            _popupsService.ShowPopup(WindowType.StartPuzzle).Forget();
        }
    }
}