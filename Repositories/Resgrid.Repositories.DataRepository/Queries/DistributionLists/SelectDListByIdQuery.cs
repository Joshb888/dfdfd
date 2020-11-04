﻿using Resgrid.Model;
using Resgrid.Model.Repositories.Queries.Contracts;
using Resgrid.Repositories.DataRepository.Configs;
using Resgrid.Repositories.DataRepository.Extensions;

namespace Resgrid.Repositories.DataRepository.Queries.DistributionLists
{
	public class SelectDListByIdQuery : ISelectQuery
	{
		private readonly SqlConfiguration _sqlConfiguration;
		public SelectDListByIdQuery(SqlConfiguration sqlConfiguration)
		{
			_sqlConfiguration = sqlConfiguration;
		}

		public string GetQuery()
		{
			var query = _sqlConfiguration.SelectDListByIdQuery
										 .ReplaceQueryParameters(_sqlConfiguration.SchemaName,
																 string.Empty,
																 _sqlConfiguration.ParameterNotation,
																new string[] {
																				"%LISTID%"
																			  },
																 new string[] {
																				"ListId",
																			  },
																 new string[] {
																				"%DISTRIBUTIONLISTSTABLE%",
																				"%DISTRIBUTIONLISTMEMBERSTABLE%"
																 },
																 new string[] {
																				_sqlConfiguration.DistributionListsTable,
																				_sqlConfiguration.DistributionListMembersTable
																 }
																 );

			return query;
		}

		public string GetQuery<TEntity>() where TEntity : class, IEntity
		{
			throw new System.NotImplementedException();
		}
	}
}
