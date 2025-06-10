namespace CMMSAPP.Domain.Enums;

using System.ComponentModel.DataAnnotations;

public enum AssetStatusTypeEnum
{
    [Display(Name = "فعال")]
    Active = 0,

    [Display(Name = "غیرفعال")]
    Inactive = 1,

    [Display(Name = "در حال تعمیر")]
    UnderMaintenance = 2,

    [Display(Name = "در انبار")]
    InStock = 3,

    [Display(Name = "اسقاط شده")]
    Decommissioned = 4
}
