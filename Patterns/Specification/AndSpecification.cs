namespace Patterns.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return this.left.IsSatisfiedBy(candidate) && this.right.IsSatisfiedBy(candidate);
        }
    }
}