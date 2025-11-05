using System;

namespace Services.Puzzles
{
    public class PuzzleModel
    {
        public int CurrentPuzzle { get; private set; } = -1;
        public int CurrentDetailsCount { get; private set; }

        // Ивенты просто формальные для примера работы модели
        public event Action<int> OnPuzzleChanged;
        public event Action<int> OnDetailsChanged;

        public void ChangeCurrentPuzzle(int puzzleIndex)
        {
            if (CurrentPuzzle == puzzleIndex)
                return;

            CurrentPuzzle = puzzleIndex;
            OnPuzzleChanged?.Invoke(CurrentPuzzle);
        }
        
        public void ChangeCurrentDetailsCount(int detailsIndex)
        {
            if (CurrentDetailsCount == detailsIndex)
                return;

            CurrentDetailsCount = detailsIndex;
            OnDetailsChanged?.Invoke(CurrentDetailsCount);
        }
    }
}