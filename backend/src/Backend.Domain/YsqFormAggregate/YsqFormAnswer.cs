using Backend.Shared.Domain;
using ErrorOr;

namespace Backend.Domain.YsqFormAggregate;

public class YsqFormAnswer : ValueObject {
    private YsqFormAnswer(
        int         questionIndex,
        YsqResponse response
    ) {
        QuestionIndex = questionIndex;
        Response      = response;
    }

    public int         QuestionIndex { get; }
    public YsqResponse Response      { get; }

    public static ErrorOr<YsqFormAnswer> Create(
        int         questionIndex,
        YsqResponse response
    ) {
        var ysqFormAnswer = new YsqFormAnswer(
            response: response,
            questionIndex: questionIndex
        );

        return ysqFormAnswer;
    }

    public override IEnumerable<object?> GetEqualityComponents() {
        yield return QuestionIndex;
        yield return Response;
    }
}
