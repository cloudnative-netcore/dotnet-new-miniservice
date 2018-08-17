using System.Collections.Generic;
using Company.Application.TodoWebApi.Dtos;
using MediatR;

namespace Company.Application.TodoWebApi.v1.UseCases.GetTodos
{
	public class GetTodosRequest : IRequest<GetTodosResponse>
	{
	}

	public class GetTodosResponse
	{
		public List<TodoDto> Result { get; set; }
	}
}