using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeTask.Models;

public class MyFolder : ISystemItem
{
	public List<ISystemItem> SystemItems { get; }
	public string? Name { get; set; }
	public string? Location { get; set; }
	public double Size
	{
		get { Console.WriteLine(Name); return SystemItems.Sum(item => item.Size); }
	}

	public MyFolder(string? name, string? location)
	{
		Name = name;
		Location = location;
		SystemItems = new();
	}

	public void Add(ISystemItem item)
	{
		item.Location = $@"{Location} {item.Name}";
		SystemItems.Add(item);
	}
}