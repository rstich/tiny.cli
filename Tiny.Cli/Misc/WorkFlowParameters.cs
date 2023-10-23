﻿namespace Tiny.Cli.Misc;

public class WorkFlowParameters
{
    public string? Directory { get; set; }
    public SearchOption? SearchOption { get; set; }
    public string? FilePath { get; set; }
    public int? Resize { get; set; }
    public string? OutPutDir { get; set; }
    
    public string ApiKey { get; set; } = string.Empty;
}