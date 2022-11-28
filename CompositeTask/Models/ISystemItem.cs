namespace CompositeTask.Models;

public interface ISystemItem
{
    string? Name { get; set; }
    string? Location { get; set; }
    double Size { get; }
}