using Petstore.List.DataLayer;
using Petstore.List.Model;
using System.Collections.Generic;
using System.Linq;

namespace Petstore.List.BusinessLogic
{
    public class PetstoreLogic
    {
        private IPetstoreService dataService;

        public PetstoreLogic(IPetstoreService dataService)
        {
            this.dataService = dataService;
        }

        public List<Pet> GetAvailablePets()
        {
            var availableList = dataService.GetAvailablePets();

            return availableList.Where(c => c.Category != null)
                .OrderBy(s => s.Category.Name)
                .ThenByDescending(n => n.Name).ToList();
        }
    }
}
