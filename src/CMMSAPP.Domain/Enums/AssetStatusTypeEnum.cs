namespace CMMSAPP.Domain.Enums;
public enum AssetStatusTypeEnum : int
{
    [Display(Name = "فعال")]
    Active = 1,

    [Display(Name = "غیرفعال")]
    Inactive = 2,

    [Display(Name = "در حال تعمیر")]
    UnderMaintenance = 3,

    [Display(Name = "در انبار")]
    InStock = 4,

    [Display(Name = "اسقاط شده")]
    Decommissioned = 5
}
