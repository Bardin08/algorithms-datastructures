namespace PathSearch.PathFinders.Statistics;

public interface ITypedObserver<in TContext>
{
    public void Handle(TContext context);
}