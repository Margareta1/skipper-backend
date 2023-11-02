using skipper_backend.Identity;
using skipper_backend.Models.SurveyCreator;
using skipper_backend.Models.SurveySolver;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddSurveyDto
    {
        public string? Rgb { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<TextInputDto> Questions { get; set; }
        public List<string> AssigneesUsernames { get; set; }
    }

    public class CheckboxDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
    }

    public class NumberInputDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int? DefaultValue { get; set; }
    }

    public class RadioButtonDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
    }

    public class RadioGroupDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public List<InputOptionsDto> RadioOptions { get; set; }
    }

    public class InputOptionsDto
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }

    public class RateDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public bool AllowHalf { get; set; }
        public double DefaultValue { get; set; }
    }

    public class SelectMultipleDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public List<InputOptionsDto> SelectOptions { get; set; }
    }

    public class SelectSingleDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public double DefaultValue { get; set; }
        public List<InputOptionsDto> SelectOptions { get; set; }
    }

    public class SliderDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public double DefaultValue { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string? LabelLeft { get; set; }
        public string? LabelRight { get; set; }
    }

    public class TextAreaDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public string? Placeholder { get; set; }
    }

    public class TextInputDto
    {
        public string Label { get; set; }
        public int OrderKey { get; set; }
        public string? Placeholder { get; set; }
    }
}
