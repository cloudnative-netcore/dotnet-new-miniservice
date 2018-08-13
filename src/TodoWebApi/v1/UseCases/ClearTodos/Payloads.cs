using MediatR;

namespace TodoWebApi.v1.UseCases.ClearTodos
{
	public class ClearTodosRequest : IRequest<ClearTodosResponse>
	{
	}

	public class ClearTodosResponse
	{
		public bool Result { get; set; }
	}
}