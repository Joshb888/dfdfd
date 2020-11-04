﻿using Resgrid.Model;
using Resgrid.Model.Repositories.Queries.Contracts;
using Resgrid.Repositories.DataRepository.Configs;
using Resgrid.Repositories.DataRepository.Extensions;

namespace Resgrid.Repositories.DataRepository.Queries.Departments
{
	public class SelectDepartmentByUsernameQuery : ISelectQuery
	{
		private readonly SqlConfiguration _sqlConfiguration;
		public SelectDepartmentByUsernameQuery(SqlConfiguration sqlConfiguration)
		{
			_sqlConfiguration = sqlConfiguration;
		}

		public string GetQuery()
		{
			var query = _sqlConfiguration.SelectDepartmentByUsernameQuery
										 .ReplaceQueryParameters(_sqlConfiguration.SchemaName,
																 string.Empty,
																 _sqlConfiguration.ParameterNotation,
																new string[] {
																				"%USERNAME%"
																			  },
																 new string[] {
																				"Username",
																			  },
																 new string[] {
																				"%DEPARTMENTSTABLE%",
																				"%DEPARTMENTMEMBERSTABLE%",
																				"%USERSTABLE%"
																 },
																 new string[] {
																				_sqlConfiguration.DepartmentsTable,
																				_sqlConfiguration.DepartmentMembersTable,
																				_sqlConfiguration.UserTable
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
