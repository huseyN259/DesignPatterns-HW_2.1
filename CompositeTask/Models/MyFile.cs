using CompositeTask.Models;

public class File : ISystemItem
{
	public string? Name { get; set; }
	public string? Location { get; set; }
	public double Size { get; }

	public File(string? name, double size, string? location = "")
	{
		Name = name;
		Location = location;
		Size = size;
	}
}