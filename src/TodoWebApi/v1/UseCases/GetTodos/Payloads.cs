using MediatR;
using System.Collections.Generic;
using TodoWebApi.Dtos;

namespace TodoWebApi.v1.UseCases.GetTodos
{
	public class GetTodosRequest : IRequest<GetTodosResponse>
	{
	}

	public class GetTodosResponse
	{
		public List<TodoDto> Result { get; set; }
	}
}