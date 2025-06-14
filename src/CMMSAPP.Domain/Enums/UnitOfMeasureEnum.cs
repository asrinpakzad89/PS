namespace CMMSAPP.Domain.Enums;

public enum UnitOfMeasureEnum :int
{
    [Display(Name = "ایکومزا")]
    Ikumza = 1,

    [Display(Name = "بسته")]
    Package = 2,

    [Display(Name = "تن")]
    Ton = 3,

    [Display(Name = "تومان")]
    Toman = 4,

    [Display(Name = "درجه‌سانتیگراد")]
    CelsiusDegree = 5,

    [Display(Name = "درصد")]
    Percent = 6,

    [Display(Name = "دست")]
    Hand = 7,

    [Display(Name = "دستگاه")]
    Device = 8,

    [Display(Name = "نفر")]
    Person = 9,

    [Display(Name = "دور")]
    Turn = 10,

    [Display(Name = "روز")]
    Day = 11,

    [Display(Name = "ریال")]
    Rial = 12,

    [Display(Name = "ساعت")]
    Hour = 13,

    [Display(Name = "سانتیمتر")]
    Centimeter = 14,

    [Display(Name = "سبد")]
    Basket = 15,

    [Display(Name = "شاخه")]
    Branch = 16,

    [Display(Name = "عدد")]
    Number = 17,

    [Display(Name = "قالب")]
    Mold = 18,

    [Display(Name = "قالب قند")]
    SugarMold = 19,

    [Display(Name = "کیلوگرم")]
    Kilogram = 20,

    [Display(Name = "گرم")]
    Gram = 21,

    [Display(Name = "لیتر")]
    Liter = 22,

    [Display(Name = "متر")]
    Meter = 23,

    [Display(Name = "مخزن")]
    Tank = 24,

    [Display(Name = "میلیمتر")]
    Millimeter = 25,

    [Display(Name = "میلیون ریال")]
    MillionRial = 26,

    [Display(Name = "واگن قند سفید")]
    WhiteSugarWagon = 27,

    [Display(Name = "واگن قند سبز")]
    GreenSugarWagon = 28,
}
