using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Data.QueryRepository;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;


namespace AspNetCoreSpa.Application.Services
{
    public class SecurityCodeService : ISecurityCodeService
    {
        private readonly ISecurityCodesRepository _securityCodesRepository;
        private readonly SecurityCodeQueryRepository _securityCodeQueryRepository;
        private readonly IUnitOfWorks _unitOfWorks;

        public SecurityCodeService(ISecurityCodesRepository securityCodesRepository,
            SecurityCodeQueryRepository securityCodeQueryRepository,
            IUnitOfWorks unitOfWorks)
        {
            _securityCodesRepository = securityCodesRepository;
            _securityCodeQueryRepository = securityCodeQueryRepository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task RemoveExpiredSecurityCodesAsync()
        {
            var codes = await _securityCodeQueryRepository.GetExpiredSecurityCodesAsync();

            if (codes.Any())
            {
                _securityCodesRepository.Delete(codes);
                await _unitOfWorks.CommitAsync();
            }
        }
    }
}