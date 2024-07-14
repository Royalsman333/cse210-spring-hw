//This is the video class
class Video {
    //This is where the title is stored
    private string title;
    //This is where the author is stored
    private string author;
    //This is where the duration time of the video is.
    private int lengthInSeconds;
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length) {
        this.title = title;
        this.author = author;
        lengthInSeconds = length;
    }

    public void AddComment(Comment comment) {
        comments.Add(comment);
    }

    public int GetNumberOfComments() {
        return comments.Count;
    }

    // This is how the program will display all of the information together
    public void DisplayDetails() {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Length: " + lengthInSeconds + " seconds");
        Console.WriteLine("Number of Comments: " + GetNumberOfComments());
        Console.WriteLine("Comments:");

        foreach (var comment in comments) {
            Console.WriteLine("Commenter: " + comment.GetCommenterName());
            Console.WriteLine("Comment: " + comment.GetCommentText());
            Console.WriteLine();
        }
    }
}
