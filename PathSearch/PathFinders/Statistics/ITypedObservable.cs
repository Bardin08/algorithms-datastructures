namespace PathSearch.PathFinders.Statistics;

internal interface ITypedObservable<TReturnType>
{
    void Subscribe(ITypedObserver<TReturnType> observer);
    void Notify(TReturnType observable);
}