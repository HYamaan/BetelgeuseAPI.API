namespace BetelgeuseAPI.Domain.Enum;

public enum NotificationsTitle
{
    NewRewardPoint = 1,
    NewPurchaseCompleted = 2,
    NewMeetingRequest = 3,
    WaitingQuizResult = 4,
    UpdatedQuizResult = 5,
    UpdatedCourse = 6
}

public static class NotificationsTitleStrings
{
    public const string NewRewardPoint = "New reward point";
    public const string NewPurchaseCompleted = "New purchase completed";
    public const string NewMeetingRequest = "New meeting request";
    public const string WaitingQuizResult = "Waiting quiz result";
    public const string UpdatedQuizResult = "Updated quiz result";
    public const string UpdatedCourse = "Updated course";
}
