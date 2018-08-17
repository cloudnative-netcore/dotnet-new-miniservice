using MediatR;

namespace Company.Application.TodoWebApi.v1.UseCases.ClearTodos
{
	public class ClearTodosRequest : IRequest<ClearTodosResponse>
	{
	}

	public class ClearTodosResponse
	{
		public bool Result { get; set; }
	}
}