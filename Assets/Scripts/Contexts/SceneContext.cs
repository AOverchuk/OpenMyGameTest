using Cysharp.Threading.Tasks;
using Services.Popups;
using Services.Puzzles;
using UnityEngine;

namespace Contexts
{
    //притаскивать DI container не стал, просто руками собираю зависимости для примера
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private PuzzlesService PuzzlesService;
        [SerializeField] private RectTransform PopupsRoot;

        private PopupsFactory _popupsFactory;
        private PopupsService _popupsService;
        private PuzzleModel _puzzleModel;
        
        private void Awake()
        {
            _puzzleModel = new PuzzleModel();
            _popupsService = new PopupsService();
            var servicesContext = new ServicesContext(PuzzlesService, _popupsService);
            _popupsFactory = new PopupsFactory(servicesContext, _puzzleModel, PopupsRoot);
            _popupsService.Init(_popupsFactory);
        }

        private void Start() => _popupsService.ShowPopup(WindowType.ChoosePuzzle).Forget();
    }
}