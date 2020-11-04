﻿using Resgrid.Model;
using Resgrid.Model.Repositories.Queries.Contracts;
using Resgrid.Repositories.DataRepository.Configs;
using Resgrid.Repositories.DataRepository.Extensions;

namespace Resgrid.Repositories.DataRepository.Queries.Messages
{
	public class SelectMessageByIdQuery : ISelectQuery
	{
		private readonly SqlConfiguration _sqlConfiguration;
		public SelectMessageByIdQuery(SqlConfiguration sqlConfiguration)
		{
			_sqlConfiguration = sqlConfiguration;
		}

		public string GetQuery()
		{
			var query = _sqlConfiguration.SelectMessageByIdQuery
										 .ReplaceQueryParameters(_sqlConfiguration.SchemaName,
																 string.Empty,
																 _sqlConfiguration.ParameterNotation,
																new string[] {
																				"%MESSAGEID%"
																			  },
																 new string[] {
																				"MessageId",
																			  },
																 new string[] {
																				"%MESSAGESTABLE%",
																				"%MESSAGERECIPIENTSTABLE%"
																 },
																 new string[] {
																				_sqlConfiguration.MessagesTable,
																				_sqlConfiguration.MessageRecipientsTable
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
