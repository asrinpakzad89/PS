namespace CMMSAPP.Domain.Enums;

public enum ShapeEnum : int
{

    [Display(Name = "نیم‌استوانه‌ای")]
    SemiCylindrical = 1,

    [Display(Name = "مکعب مستطیل")]
    RectangularPrism = 2,

    [Display(Name = "مخروطی")]
    Conical = 3,

    [Display(Name = "هرمی")]
    Pyramidal = 4,

    [Display(Name = "حلزونی")]
    Helical = 5,

    [Display(Name = "مثلثی")]
    Triangular = 6,

    [Display(Name = "بدون شکل هندسی خاص")]
    Irregular = 7,

    [Display(Name = "استوانه‌ای")]
    Cylindrical = 8,

}
