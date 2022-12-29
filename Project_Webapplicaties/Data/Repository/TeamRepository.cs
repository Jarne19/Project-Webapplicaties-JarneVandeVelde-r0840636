using System.Collections.Generic;
using System.Linq;
using Definux.Utilities.Objects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data.Repository.Interfaces;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository
{
    public class TeamRepository:ITeamRepository
    {
        private readonly VwGerheideContext _context;

        public TeamRepository(VwGerheideContext context)
        {
            _context = context;
        }
        public PaginatedList<Team> GetTeams(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1)
        {
            List<Team> items;
            if (SearchText != "" && SearchText != null)
            {
                items = _context.Teams.Where(x=>x.Name.Contains(SearchText)).ToList();
            }
            else
                items = _context.Teams.ToList();
            PaginatedList<Team> retItems = new PaginatedList<Team>(){Items = items};
            return retItems;
        }
    }
}
