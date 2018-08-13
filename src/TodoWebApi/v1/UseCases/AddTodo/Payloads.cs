using MediatR;
using System.ComponentModel.DataAnnotations;
using TodoWebApi.Dtos;

namespace TodoWebApi.v1.UseCases.AddTodo
{
		public class AddTodoRequest : IRequest<AddTodoResponse>
	{
		public int? Order { get; set; } = 1;
		[Required] public string Title { get; set; }
		[Required] public string Url { get; set; }
		public bool? Completed { get; set; } = false;
	}

	public class AddTodoResponse
	{
		public TodoDto Result { get; set; }
	}
}