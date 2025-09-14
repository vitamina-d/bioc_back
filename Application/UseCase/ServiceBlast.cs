namespace Application
{
    public class ServiceBlast : IServiceBlast
    {
        private readonly IBlastClient _blastClient;
        public ServiceBlast(IBlastClient blastClient)
        {
            _blastClient = blastClient;

        }

        public Task<string> Connect(string sequence)
        {
            var res = _blastClient.BlastX(sequence);
            return res;
        }

    }
}
