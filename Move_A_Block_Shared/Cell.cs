namespace Move_A_Block_Shared;

using System.ComponentModel.DataAnnotations;
public class Cell
{
    [Required]
    public string content { get; set; } = string.Empty;

    [Required]
    public int index { get; set; } = 0;
}
