namespace Core.Common.Contracts
{
    /// <summary>
    /// Serves to identify the unique 'id' column for persistence reasons
    /// </summary>
    public interface IIdentifiableEntity
    {
        int EntityId { get; set; }
    }
}
