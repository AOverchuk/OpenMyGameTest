using Services.Popups;
using Services.Puzzles;

namespace Contexts
{
    public class ServicesContext
    {
        public readonly PuzzlesService Puzzles;
        public PopupsService Popups;

        public ServicesContext(PuzzlesService puzzles, PopupsService popups)
        {
            Puzzles = puzzles;
            Popups = popups;
        }
        
        public void SetPopupsService(PopupsService popups) => Popups = popups;
    }
}