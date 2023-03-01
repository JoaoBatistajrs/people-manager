namespace Domain.Models;

public class Employee
{
    public Employee() { }
    public Employee(int id, string name, string adress, string phone, string professionalEmail, string department, decimal salary, DateTime admissionDate)
    {
        Id = id;
        Name = name;
        Adress = adress;
        Phone = phone;
        ProfessionalEmail = professionalEmail;
        Department = department;
        Salary = salary;
        AdmissionDate = admissionDate;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public string Phone { get; set; }
    public string ProfessionalEmail { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTimeOffset? AdmissionDate { get; set; }
}

