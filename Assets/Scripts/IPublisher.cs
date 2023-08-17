public interface IPublisher
{
    void AttachObserver(IPlayerObserver observer);

    void RemoveObserver(IPlayerObserver observer);

    void Notify();

}
