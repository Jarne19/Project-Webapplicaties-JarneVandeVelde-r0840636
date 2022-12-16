﻿using Definux.Utilities.Objects;
using Microsoft.Data.SqlClient;
using Project_Webapplicaties.Models;

namespace Project_Webapplicaties.Data.Repository.Interfaces
{
    public interface ITeamRepository
    {
        PaginatedList<Team> GetTeams(string SortProperty,SortOrder sortOrder,string SearchText="",int pageIndex = 1);
    }
}
