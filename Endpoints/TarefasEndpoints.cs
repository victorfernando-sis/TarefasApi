using System;
using Dapper.Contrib.Extensions;
using TarefasAPI.Data;
using static TarefasAPI.Data.TarefaContext;

namespace TarefasAPI.Endpoints
{
	public static class TarefasEndpoints
	{
		public static void MapTarefasEndpoints(this WebApplication app)
		{
			app.MapGet("/", () => $"Bem vindo a API Tarefas {DateTime.Now}");

			app.MapGet("/tarefas", async(GetConnection connectionGetter) =>
			{
				try
				{
				using var con = await connectionGetter();
				var tarefas = con.GetAll<Tarefa>().ToList();

				if (tarefas is null) return Results.NotFound(); 

				return Results.Ok(tarefas);
				}
				catch (Exception ex)
				{
					throw;
				}
			});
		}
	}
}

