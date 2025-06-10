namespace CMMSAPP.Domain.Enums;

public enum ToolTypeEnum
{
    [Display(Name = "ابزار دستی")]
    HandTool = 1,

    [Display(Name = "ابزار برقی")]
    PowerTool = 2,

    [Display(Name = "ابزار اندازه‌گیری")]
    MeasuringTool = 3,

    [Display(Name = "ابزار برشی")]
    CuttingTool = 4,

    [Display(Name = "ابزار جابه‌جایی")]
    LiftingTool = 5,

    [Display(Name = "ابزار ایمنی")]
    SafetyTool = 6,

    [Display(Name = "ابزار نگهداری")]
    MaintenanceTool = 7
}
