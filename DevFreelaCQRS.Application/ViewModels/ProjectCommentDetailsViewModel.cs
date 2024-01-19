namespace DevFreelaCQRS.Application.ViewModels
{
    public class ProjectCommentDetailsViewModel
    {
        public ProjectCommentDetailsViewModel(string content, string projectTitle, string username)
        {
            Content = content;
            ProjectTitle = projectTitle;
            Username = username;
        }

        public string Content { get; private set; }
        public string ProjectTitle { get; private set; }
        public string Username { get; private set; }
    }
}
