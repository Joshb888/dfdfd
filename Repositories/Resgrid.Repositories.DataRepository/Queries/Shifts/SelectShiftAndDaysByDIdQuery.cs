﻿using Resgrid.Model;
using Resgrid.Model.Repositories.Queries.Contracts;
using Resgrid.Repositories.DataRepository.Configs;
using Resgrid.Repositories.DataRepository.Extensions;

namespace Resgrid.Repositories.DataRepository.Queries.Shifts
{
	public class SelectShiftAndDaysByDIdQuery : ISelectQuery
	{
		private readonly SqlConfiguration _sqlConfiguration;
		public SelectShiftAndDaysByDIdQuery(SqlConfiguration sqlConfiguration)
		{
			_sqlConfiguration = sqlConfiguration;
		}

		public string GetQuery()
		{
			var query = _sqlConfiguration.SelectShiftsByDidJSONQuery
										 .ReplaceQueryParameters(_sqlConfiguration.SchemaName,
																 string.Empty,
																 _sqlConfiguration.ParameterNotation,
																new string[] {
																				"%DID%"
																},
																 new string[] {
																				"DepartmentId"
																 },
																 new string[] {
																				"%SHIFTSTABLE%",
																				"%SHIFTDAYSTABLE%"
																 },
																 new string[] {
																				_sqlConfiguration.ShiftsTable,
																				_sqlConfiguration.ShiftDaysTable
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
