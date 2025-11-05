using System;
using System.Collections.Generic;
using Contexts;
using Popups.ChoosePuzzle;
using Popups.StartPuzzle;
using Services.Puzzles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Popups
{
    public class PopupsFactory
    {
        private readonly ServicesContext _servicesContext;
        private readonly PuzzleModel _puzzleModel;
        private readonly Transform _popupsRoot;
        private Dictionary<WindowType, GameObject> _windowPrefabs;
        
        public PopupsFactory(ServicesContext servicesContext, PuzzleModel puzzleModel, Transform popupsRoot)
        {
            _servicesContext = servicesContext;
            _puzzleModel = puzzleModel;
            _popupsRoot = popupsRoot;
            LoadPrefabs();
        }

        public IPopupPresenter CreatePresenter(WindowType type) =>
            type switch
            {
                WindowType.ChoosePuzzle => CreateChoosePuzzlePresenter(type),
                WindowType.StartPuzzle => CreateStartPuzzlePresenter(type),
                _ => throw new ArgumentException($"No creation method for window type {type}"),
            };
        
        private IPopupPresenter CreateChoosePuzzlePresenter(WindowType type)
        {
            var view = InstantiatePrefab<ChoosePuzzleView>(type);
            return new ChoosePuzzlePresenter(view, _puzzleModel, _servicesContext.Puzzles, _servicesContext.Popups);
        }
        
        private IPopupPresenter CreateStartPuzzlePresenter(WindowType type)
        {
            var view = InstantiatePrefab<StartPuzzleView>(type);
            return new StartPuzzlePresenter(view, _puzzleModel, _servicesContext.Puzzles);
        }
        
        private T InstantiatePrefab<T>(WindowType type) where T : MonoBehaviour
        {
            GameObject prefab = _windowPrefabs[type];
            GameObject instance = Object.Instantiate(prefab, _popupsRoot);
            return instance.GetComponent<T>();
        }
    
        //Resources не очень, используется для примера
        private void LoadPrefabs() =>
            _windowPrefabs = new Dictionary<WindowType, GameObject>
            {
                [WindowType.ChoosePuzzle] = Resources.Load<GameObject>("ChoosePuzzlePopup"),
                [WindowType.StartPuzzle] = Resources.Load<GameObject>("StartPuzzlePopup"),
            };
    }
}