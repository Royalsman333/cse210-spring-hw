//I made the class for comments
class Comment {
    private string commenterName;
    private string commentText;

//This puts the name of the commenter with the comment that they made
    public Comment(string name, string text) {
        commenterName = name;
        commentText = text;
    }

    // Getters for comment details
    public string GetCommenterName() {
        return commenterName;
    }

    public string GetCommentText() {
        return commentText;
    }
}