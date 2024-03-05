using CA.RoadReady.Domain.Abstractions;


namespace CA.RoadReady.Domain.Reviews
{
    public static class ReviewErrors
    {
        public static readonly Error NotElegible = new Error(
            "Review.NotElegible",
            "Not elegible to leave a Review yet"
        );

    }
}
