using System;
using System.Collections.Generic;
using System.Text;

namespace MicroQuiz.Services.Quizzes.Core.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; set; }
    }
}
