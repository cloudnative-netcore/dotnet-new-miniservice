using System.Threading;
using System.Threading.Tasks;
using Company.Application.TodoWebApi.Extensions;
using NetCoreKit.Domain;
using NetCoreKit.Infrastructure.AspNetCore.CleanArch;
using NetCoreKit.Infrastructure.EfCore.Extensions;

namespace Company.Application.TodoWebApi.v1.UseCases.GetTodo
{
	public class RequestHandler : RequestHandlerBase<GetTodoRequest, GetTodoResponse>
	{
		public RequestHandler(IUnitOfWorkAsync uow, IQueryRepositoryFactory queryRepositoryFactory)
			: base(uow, queryRepositoryFactory)
		{
		}

		public override async Task<GetTodoResponse> Handle(GetTodoRequest request, CancellationToken cancellationToken)
		{
			var queryRepository = QueryRepositoryFactory.QueryEfRepository<Domain.Todo>();
			var result = await queryRepository.GetByIdAsync(request.Id);
			return new GetTodoResponse
			{
				Result = result.ToDto()
			};
		}
	}
}