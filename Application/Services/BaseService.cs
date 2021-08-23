using Domain.Interfacse;

namespace Application.Services
{
    public abstract class BaseService
    {
        #region Fields :
        protected readonly IUnitOfWork unitOfWork;
        #endregion
        #region CTORS :
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
    }
}
