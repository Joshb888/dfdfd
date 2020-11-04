﻿using Resgrid.Model;
using Resgrid.Model.Repositories.Queries.Contracts;
using Resgrid.Repositories.DataRepository.Configs;
using Resgrid.Repositories.DataRepository.Extensions;

namespace Resgrid.Repositories.DataRepository.Queries.Units
{
	public class SelectLastUnitStateByUnitIdQuery : ISelectQuery
	{
		private readonly SqlConfiguration _sqlConfiguration;
		public SelectLastUnitStateByUnitIdQuery(SqlConfiguration sqlConfiguration)
		{
			_sqlConfiguration = sqlConfiguration;
		}

		public string GetQuery()
		{
			var query = _sqlConfiguration.SelectLastUnitStateByUnitIdQuery
				.ReplaceQueryParameters(_sqlConfiguration.SchemaName,
					string.Empty,
					_sqlConfiguration.ParameterNotation,
					new string[] {
						"%UNITID%"
					},
					new string[] {
						"UnitId"
					},
					new string[] {
						"%UNITSTATESTABLE%",
						"%UNITSTABLE%"
					},
					new string[] {
						_sqlConfiguration.UnitStatesTable,
						_sqlConfiguration.UnitsTable
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
