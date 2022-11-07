namespace HalfboardStats.Core
{
    public interface IDateTimeProvider
    {
        int CurrentYear { get; }
        int CurrentMonth { get; }
    }
}