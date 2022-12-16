using Definux.Utilities.Objects;
using Microsoft.Data.SqlClient;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_Webapplicaties.Data.Repository
{
    public class RefereeRepository : IRefereeRepository
    {
        private readonly VwGerheideContext _context;

        public RefereeRepository(VwGerheideContext context)
        {
            _context = context;
        }
        public PaginatedList<Referee> GetReferee(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1)
        {
            List<Referee> items;
            if(SearchText != "" && SearchText != null)
            {
                items= _context.Referees.Where(x=>x.Name.Contains(SearchText)).ToList();
            }
            else
                items = _context.Referees.ToList();
            PaginatedList<Referee> retItems = new PaginatedList<Referee>() { Items = items };
            return retItems;
        }
        
    }
}
