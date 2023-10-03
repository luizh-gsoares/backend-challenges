﻿namespace VUTTR.Domain.Tools;

public class Tool : Entity
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public List<Tag> Tags { get; set; }
}