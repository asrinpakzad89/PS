namespace CMMSAPP.Domain.Enums;

using System.ComponentModel.DataAnnotations;

public enum MaterialTypeEnum
{
    [Display(Name = "ورق فولادی")]
    SteelSheet = 0,

    [Display(Name = "ورق استیل")]
    StainlessSteelSheet = 1,

    [Display(Name = "ورق گالوانیزه")]
    GalvanizedSheet = 2,

    [Display(Name = "ورق کربن")]
    CarbonSheet = 3,

    [Display(Name = "چدن")]
    CastIron = 4,

    [Display(Name = "بتن")]
    Concrete = 5,

    [Display(Name = "پلی‌اتیلن")]
    Polyethylene = 6,

    [Display(Name = "پلاستیکی")]
    Plastic = 7
}
