﻿using Resgrid.Model;
using Resgrid.Model.Repositories.Queries.Contracts;
using Resgrid.Repositories.DataRepository.Configs;
using Resgrid.Repositories.DataRepository.Extensions;

namespace Resgrid.Repositories.DataRepository.Queries.Shifts
{
	public class SelectShiftPersonByShiftIdQuery : ISelectQuery
	{
		private readonly SqlConfiguration _sqlConfiguration;
		public SelectShiftPersonByShiftIdQuery(SqlConfiguration sqlConfiguration)
		{
			_sqlConfiguration = sqlConfiguration;
		}

		public string GetQuery()
		{
			var query = _sqlConfiguration.SelectShiftPersonByShiftIdQuery
				.ReplaceQueryParameters(_sqlConfiguration.SchemaName,
					_sqlConfiguration.ShiftPersonsTable,
					_sqlConfiguration.ParameterNotation,
					new string[] { "%SHIFTID%" },
					new string[] { "ShiftId" });

			return query;
		}

		public string GetQuery<TEntity>() where TEntity : class, IEntity
		{
			throw new System.NotImplementedException();
		}
	}
}
