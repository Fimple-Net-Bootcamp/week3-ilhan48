namespace Week3.Application.DTOs;

public class HealthStatusUpdateDto
{
    public DateTime ExaminationDate { get; set; }
    public bool VaccinationStatus { get; set; }
    public string DiseaseStatus { get; set; }
    public string TreatmentInfo { get; set; }
    public string Notes { get; set; }
}
