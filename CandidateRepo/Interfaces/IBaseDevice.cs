namespace CandidateRepo.Interfaces
{
    public interface IBaseDevice
    {
        string Name { get; }

        void Reboot();

        void GetCurrentState();

        void UpdateParams();

        void RegisterDevice();
    }
}
