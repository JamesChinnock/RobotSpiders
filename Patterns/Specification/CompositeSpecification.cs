namespace Patterns.Specification
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);
        
        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }
    }
}
