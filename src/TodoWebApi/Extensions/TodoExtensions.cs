using TodoWebApi.Domain;
using TodoWebApi.Dtos;

namespace TodoWebApi.Extensions
{
	public static class TodoExtensions
	{
		public static TodoDto ToDto(this Todo todo)
		{
			return new TodoDto
			{
				Id = todo.Id,
				Title = todo.Title,
				Url = todo.Url,
				Completed = todo.Completed ?? false,
				Order = todo.Order ?? 1
			};
		}
		}
}