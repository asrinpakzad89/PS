namespace CMMSAPP.Domain.Enums;

public enum AssetTypeEnum : int
{
    [Display(Name = "مونتاژ")]
    Assemble = 1,

    [Display(Name = "قطعه")]
    Part = 2,
}
