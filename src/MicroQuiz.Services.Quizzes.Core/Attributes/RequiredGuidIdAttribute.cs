namespace MicroQuiz.Services.Quizzes.Core.Attributes
{
    public class RequiredGuidIdAttribute : NotDefaultAttribute
    {
        private const string _errorMessage = "The {0} field is required.";

        public RequiredGuidIdAttribute()
            :base(_errorMessage) { }
    }
}
