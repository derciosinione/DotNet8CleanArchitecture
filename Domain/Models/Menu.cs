using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Helper;

namespace Domain.Models;

public class Menu
{
    [Key] public Guid Id { get; set; }

    [Required] public string Name { get; set; } = null!;

    public string? CodeI18N { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Level { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Menu() { }
    
    public Menu(string name, string codeI18N = null!, bool isActive = true)
    {
        Name = name;
        IsActive = isActive;
        CodeI18N = string.IsNullOrWhiteSpace(codeI18N) ? FormatCodeI18N(Name) : FormatCodeI18N(codeI18N);
    }

    private static string FormatCodeI18N(string code)
    {
        code = Utils.RemoveAccents(code.ToUpper().Replace(" ", ""));
        code = Utils.ReplaceSpecialCharactersWithUnderscore(code);
        return $"{Constants.I18N}_{code}";
    }
}