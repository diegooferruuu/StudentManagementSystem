namespace StudentManagementSystem.Models;

public class Score
{
    #region Attributes

    private string subject;
    private int value;
    private string type;

    #endregion
    
    #region Constructors
    Score()
    {
        subject = string.Empty;
        value = 0;
        type = string.Empty;
    }

    public Score(string subject, int value, string type)
    {
        this.subject = subject;
        this.value = value;
        this.type = type;
    }
    #endregion
    
    #region Properties

    public string Subject => subject;

    public int Value => value;

    public string Type => type;

    #endregion
}