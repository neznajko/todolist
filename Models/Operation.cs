////////////////////////////////////////////////////////////////////////////////////////
namespace todolist.Models;
////////////////////////////////////////////////////////////////////////////////////////
public enum OperationStatus {
    Pending,
    InProgress,
    TacticalPause,
    TargetOffline,
    Completed,
}
////////////////////////////////////////////////////////////////////////////////////////
public class Operation {
    public int Id { get; set; }
    public required string Description { get; set; }    
    public OperationStatus Status { get; set; } = OperationStatus.Pending;
}
////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////