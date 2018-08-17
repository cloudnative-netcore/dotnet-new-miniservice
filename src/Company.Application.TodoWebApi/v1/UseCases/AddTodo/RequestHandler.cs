using System.Threading;
using System.Threading.Tasks;
using Company.Application.TodoWebApi.Domain;
using Company.Application.TodoWebApi.Extensions;
using NetCoreKit.Domain;
using NetCoreKit.Infrastructure.AspNetCore.CleanArch;

namespace Company.Application.TodoWebApi.v1.UseCases.AddTodo
{
	public class RequestHandler : TxRequestHandlerBase<AddTodoRequest, AddTodoResponse>
	{
		public RequestHandler(IUnitOfWorkAsync uow, IQueryRepositoryFactory queryRepositoryFactory)
			: base(uow, queryRepositoryFactory)
		{
		}

		public override async Task<AddTodoResponse> TxHandle(AddTodoRequest request, CancellationToken cancellationToken)
		{
			var todoRepository = UnitOfWork.Repository<Todo>();

			var todo = Todo.Load(request.Title, request.Url);

			var result = await todoRepository.AddAsync(todo);
			return new AddTodoResponse {Result = result.ToDto()};
		}
	}
}