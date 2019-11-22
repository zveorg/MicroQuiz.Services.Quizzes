using System;
using System.ComponentModel.DataAnnotations;

namespace MicroQuiz.Services.Quizzes.Core.Attributes
{
    public class NotDefaultAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "The {0} field must not have the default value";
        public NotDefaultAttribute() : base(_defaultErrorMessage) { }

        protected NotDefaultAttribute(string errorMessage) : base(errorMessage) { }

        public override bool IsValid(object value)
        {
            //NotDefault doesn't necessarily mean required
            if (value is null)
                return true;

            var type = value.GetType();
            if (type.IsValueType)
            {
                var defaultValue = Activator.CreateInstance(type);
                return !value.Equals(defaultValue);
            }

            // non-null ref type
            return true;
        }
    }
}
