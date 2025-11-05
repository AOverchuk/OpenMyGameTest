using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Puzzles
{
    /// Условный класс, который хранит список пазлов
    /// Заполняю руками, нужен только как пример сервиса
    /// MonoBehaviour для удобства заполнения в инспекторе
    public class PuzzlesService : MonoBehaviour
    {
        [SerializeField] private List<Puzzle> PuzzleSprites;

        public int GetDetailsCount(int puzzleIndex, int detailsIndex) => GetPuzzle(puzzleIndex).GetDetailsCount(detailsIndex);

        public List<Puzzle> GetPuzzles() => PuzzleSprites;
        
        public Sprite GetPuzzleSprite(int puzzleIndex) => GetPuzzle(puzzleIndex).GetSprite();
        
        public PuzzlePriceType GetPuzzlePriceType(int puzzleIndex) => GetPuzzle(puzzleIndex).GetPriceType();

        private Puzzle GetPuzzle(int index)
        {
            if (index < 0 || index >= PuzzleSprites.Count)
                throw new Exception("Invalid puzzle index");

            return PuzzleSprites[index];
        }
    }
}