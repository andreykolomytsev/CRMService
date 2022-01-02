using CRMService.DTOModels;

namespace CRMService.Interfaces
{
    public interface IJWTService
    {
        public Account ValidateToken(string token);
    }
}
