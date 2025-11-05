using Services.Popups;
using Services.Puzzles;

namespace Contexts
{
    public class ServicesContext
    {
        public readonly PuzzlesService PuzzlesService;
        public readonly PopupsService PopupsService;

        public ServicesContext(PuzzlesService puzzlesService, PopupsService popupsService)
        {
            PuzzlesService = puzzlesService;
            PopupsService = popupsService;
        }
    }
}