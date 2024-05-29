

using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course
{
    public class ContentQuizQuestionsResponseDto
    {
        public Guid Id { get; set; }
        public Languages LanguageId { get; set; }
        public string Title { get; set; }
        public required int Grade { get; set; }
        public CourseQuizQuestionType QuestionType { get; set; }
        public List<ContentUploadResponseDto>? Video { get; set; }

        public ContentUploadResponseDto? Image { get; set; }
        public List<ContentQuizAnswerResponseDto> CourseQuizAnswers { get; set; }

    }
}
