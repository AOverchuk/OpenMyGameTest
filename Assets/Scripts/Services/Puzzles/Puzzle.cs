using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Puzzles
{
    [Serializable]
    public class Puzzle
    {
        [SerializeField] private Sprite Sprite;
        /// чтобы полноценно показать работу с бесплатным, платным и рекламным пазлом нужно усложнять структуру проекта
        /// поэтому просто ограничиваюсь текстом на кнопке
        /// Сам текст был бы где-то в сервисе локализации, но опять же сделано для примера
        [SerializeField] private PuzzlePriceType PriceType;
        [SerializeField] private List<int> DetailsCount;
        
        public Sprite GetSprite() => Sprite;
        public PuzzlePriceType GetPriceType() => PriceType;
        public int GetDetailsCount(int index) => DetailsCount[index];
    }
}