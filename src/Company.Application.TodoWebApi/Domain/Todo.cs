using System;
using System.ComponentModel.DataAnnotations;
using NetCoreKit.Domain;

namespace Company.Application.TodoWebApi.Domain
{
	public sealed class Todo : EntityBase
	{
		internal Todo(string title, string url)
			: this(Guid.NewGuid(), title, url)
		{
		}

		public Todo(Guid id, string title, string url) : base(id)
		{
			Title = title;
			Url = url;
		}

		public static Todo Load(string title, string url)
		{
			return new Todo(title, url);
		}

		public static Todo Load(Guid id, string title, string url)
		{
			return new Todo(id, title, url);
		}

		public int? Order { get; private set; } = 1;
		[Required] public string Title { get; private set; }
		[Required] public string Url { get; private set; }
		public bool? Completed { get; private set; } = false;

		public Todo SetOrder(int order)
		{
			if (order <= 0)
			{
				throw new DomainException("Order could be greater than zero.");
			}

			Order = order;
			return this;
		}

		public Todo SetCompleted(bool completed)
		{
			if (Completed.HasValue && !Completed.Value)
				Completed = completed;
			return this;
		}
	}
}