using Backend.Shared.Domain;
using ErrorOr;

namespace Backend.Domain.YsqFormAggregate;

public class YsqForm : AggregateRoot {
    private readonly List<YsqFormAnswer> _answers = [];

    private YsqForm(
        string              fullName,
        string              phone,
        int                 age,
        string              degree,
        string              educationMajor,
        string              jobTitle,
        string              gender,
        List<YsqFormAnswer> answers,
        Guid?               id = null
    ) : base(id) {
        FullName       = fullName;
        Phone          = phone;
        Age            = age;
        Degree         = degree;
        EducationMajor = educationMajor;
        JobTitle       = jobTitle;
        Gender         = gender;
        _answers       = answers;
    }

    public string                       FullName       { get; private set; }
    public string                       Phone          { get; private set; }
    public int                          Age            { get; private set; }
    public string                       Degree         { get; private set; }
    public string                       EducationMajor { get; private set; }
    public string                       JobTitle       { get; private set; }
    public string                       Gender         { get; private set; }
    public IReadOnlyList<YsqFormAnswer> Answers        => _answers.AsReadOnly();

    public static ErrorOr<YsqForm> Create(
        string              fullName,
        string              phone,
        int                 age,
        string              degree,
        string              educationMajor,
        string              jobTitle,
        string              gender,
        List<YsqFormAnswer> answers,
        Guid?               id = null
    ) {
        var ysqForm = new YsqForm(
            id: id,
            answers: answers,
            gender: gender,
            jobTitle: jobTitle,
            educationMajor: educationMajor,
            degree: degree,
            age: age,
            phone: phone,
            fullName: fullName
        );

        return ysqForm;
    }
}
