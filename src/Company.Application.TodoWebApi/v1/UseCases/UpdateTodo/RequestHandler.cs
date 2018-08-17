using System;
using System.Threading;
using System.Threading.Tasks;
using Company.Application.TodoWebApi.Extensions;
using NetCoreKit.Domain;
using NetCoreKit.Infrastructure.AspNetCore.CleanArch;
using NetCoreKit.Infrastructure.EfCore.Extensions;

namespace Company.Application.TodoWebApi.v1.UseCases.UpdateTodo
{
	public class RequestHandler : TxRequestHandlerBase<UpdateTodoRequest, UpdateTodoResponse>
	{
		public RequestHandler(IUnitOfWorkAsync uow, IQueryRepositoryFactory queryRepositoryFactory)
			: base(uow, queryRepositoryFactory)
		{
		}

		public override async Task<UpdateTodoResponse> TxHandle(UpdateTodoRequest request,
			CancellationToken cancellationToken)
		{
			var commandRepository = UnitOfWork.Repository<Domain.Todo>();
			var queryRepository = QueryRepositoryFactory.QueryEfRepository<Domain.Todo>();

			var todo = await queryRepository.GetByIdAsync(request.Id);
			if (todo == null)
			{
				throw new Exception($"Could not find item #{request.Id}.");
			}

			var updated = await commandRepository.UpdateAsync(todo);
			return new UpdateTodoResponse {Result = updated.ToDto()};
		}
	}
}