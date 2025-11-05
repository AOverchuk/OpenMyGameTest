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
            var baseServicesContext = new ServicesContext(PuzzlesService, _popupsService);
            _popupsFactory = new PopupsFactory(baseServicesContext, _puzzleModel, PopupsRoot);
            _popupsService = new PopupsService(_popupsFactory);
            baseServicesContext.SetPopupsService(_popupsService);
        }

        private void Start() => _popupsService.ShowPopup(WindowType.ChoosePuzzle).Forget();
    }
}