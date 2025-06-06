namespace SolutionEx5Gateaux.Models
{
    public interface IGateauRepository
    {
        public IEnumerable<Gateau> MesGateaux { get; }

        public Gateau GetGateau(int gateauId);

        public void AddGateau(Gateau gateau);

        public void EditGateau(int id, Gateau gateau);

        public void DeleteGateau(int id);
    }
}
