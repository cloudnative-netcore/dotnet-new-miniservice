using MediatR;
using System;
using TodoWebApi.Dtos;

namespace TodoWebApi.v1.UseCases.GetTodoById
{
	public class GetTodoByIdRequest : IRequest<GetTodoByIdResponse>
	{
		public Guid Id { get; set; }
	}

	public class GetTodoByIdResponse
	{
		public TodoDto Result { get; set; }
	}
}