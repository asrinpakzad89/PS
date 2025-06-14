namespace CMMSAPP.Domain.Enums;

public enum FileOwnerTypeEnum: int
{
    [Display(Name ="تجهیز")]
    Asset = 1,

    [Display(Name = "قطعه")]
    StandardPart = 2,

    [Display(Name = "مواد مضرفی")]
    Material = 3
}

