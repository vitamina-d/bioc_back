using Application.DTO;

namespace Application
{
    public interface IServiceBlast
    {
        public Task<ResponsePlumberDto<DataBlastxDto?>> Connect(string sequence);

    }
}
