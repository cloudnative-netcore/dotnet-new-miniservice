using System;

namespace Company.Application.TodoWebApi.Dtos
{
	public class TodoDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public int Order { get; set; }
		public bool Completed { get; set; }
	}
}