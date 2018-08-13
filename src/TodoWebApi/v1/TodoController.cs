using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreKit.Infrastructure.AspNetCore;
using NetCoreKit.Infrastructure.AspNetCore.CleanArch;
using TodoWebApi.v1.UseCases.AddTodo;
using TodoWebApi.v1.UseCases.ClearTodos;
using TodoWebApi.v1.UseCases.DeleteTodo;
using TodoWebApi.v1.UseCases.GetTodoById;
using TodoWebApi.v1.UseCases.GetTodos;
using TodoWebApi.v1.UseCases.UpdateTodo;

namespace TodoWebApi.v1
{
	[ApiVersion("1.0")]
	[Route("api/todos")]
	public class TodoController : EvtControllerBase
	{
		public TodoController(IMediator eventor) : base(eventor)
		{
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return await Eventor.SendStream<GetTodosRequest, GetTodosResponse>(
				new GetTodosRequest(),
				x => x.Result);
		}

		[HttpGet("{todoId:guid}")]
		public async Task<IActionResult> Get(Guid todoId)
		{
			return await Eventor.SendStream<GetTodoByIdRequest, GetTodoByIdResponse>(
				new GetTodoByIdRequest {Id = todoId},
				x => x.Result);
		}

		[HttpPost]
		public async Task<IActionResult> Post(AddTodoRequest request)
		{
			return await Eventor.SendStream<AddTodoRequest, AddTodoResponse>(
				request,
				x => x.Result);
		}

		[HttpDelete("{todoId:guid}")]
		public async Task<IActionResult> Delete(Guid todoId)
		{
			return await Eventor.SendStream<DeleteTodoRequest, DeleteTodoResponse>(
				new DeleteTodoRequest {Id = todoId},
				x => x.Result);
		}

		[HttpDelete]
		public async Task<IActionResult> Clear()
		{
			return await Eventor.SendStream<ClearTodosRequest, ClearTodosResponse>(
				new ClearTodosRequest(),
				x => x.Result);
		}

		[HttpPut("{todoId:guid}")]
		public async Task<IActionResult> Clear(Guid todoId, UpdateTodoRequest request)
		{
			request.Id = todoId;
			return await Eventor.SendStream<UpdateTodoRequest, UpdateTodoResponse>(
				request,
				x => x.Result);
		}
	}
}