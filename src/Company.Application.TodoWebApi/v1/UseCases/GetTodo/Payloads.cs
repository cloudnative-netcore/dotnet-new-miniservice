using System;
using Company.Application.TodoWebApi.Dtos;
using MediatR;

namespace Company.Application.TodoWebApi.v1.UseCases.GetTodo
{
	public class GetTodoRequest : IRequest<GetTodoResponse>
	{
		public Guid Id { get; set; }
	}

	public class GetTodoResponse
	{
		public TodoDto Result { get; set; }
	}
}