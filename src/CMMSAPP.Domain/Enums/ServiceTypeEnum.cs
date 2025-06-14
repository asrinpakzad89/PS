namespace CMMSAPP.Domain.Enums;

public enum ServiceTypeEnum : int
{
    [Display(Name = "نگهداری و تعمیرات")]
    PM = 1,

    [Display(Name = "اقدامات اصلاحی")]
    CM = 2,
}
