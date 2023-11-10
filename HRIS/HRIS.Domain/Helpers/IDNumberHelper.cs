using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Utils;

namespace HRIS.Domain.Helpers
{
    public class IDNumberHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _format;
        private readonly int _digit;
        public IDNumberHelper(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            _format = unitOfwork.Config.GetValue<string>("SYSTEM", "ID_NUMBER_FORMAT");
            _digit = unitOfwork.Config.GetValue<int>("SYSTEM", "ID_NUMBER_DIGIT");
        }

        public string GenerateIdNumber(string keyPrefix)
        {
            var number = string.Empty;
            var prefix = _unitOfWork.Config.GetValue<string>("SYSTEM", keyPrefix);
            for (var idx = 0; idx < _digit; idx++)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 9);
                number += randomNumber.ToString();
            }
            return string.Format(_format, prefix, DateUtil.GetCurrentDate().ToString("YYMM"), number); ;
        }
    }
}
