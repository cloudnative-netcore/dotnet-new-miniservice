using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using TodoWebApi.Dtos;

namespace TodoWebApi.v1.UseCases.UpdateTodo
{
	public class UpdateTodoRequest : IRequest<UpdateTodoResponse>
	{
		public Guid Id { get; set; }
		public int? Order { get; set; } = 1;
		[Required] public string Title { get; set; }
		[Required] public string Url { get; set; }
		public bool? Completed { get; set; } = false;
	}

	public class UpdateTodoResponse
	{
		public TodoDto Result { get; set; }
	}
}