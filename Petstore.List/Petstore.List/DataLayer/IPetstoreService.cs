using Petstore.List.Model;
using System.Collections.Generic;

namespace Petstore.List.DataLayer
{
    public interface IPetstoreService
    {
        public List<Pet> GetAvailablePets();
    }
}
