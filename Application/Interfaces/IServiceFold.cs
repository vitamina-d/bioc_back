using Application.DTO;

namespace Application
{
    public interface IServiceFold
    {
        public DataPdbDto[] GetEstructures(BodyFoldDto body);
    }
}
