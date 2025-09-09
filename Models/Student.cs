namespace StudentManagementSystem.Models;

public class Student
{
    #region Attributes
    private string name;
    private string last_name;
    private int id; 
    private List<Score> scores;
    #endregion
    
    #region Constructors
    public Student()
    {
        name = String.Empty;
        last_name = String.Empty;
        id = -1;
        scores = new List<Score>();
    }

    public Student(string name, string lastName, int id)
    {
        this.name = name;
        this.last_name = lastName;
        this.id = id;
        scores = new List<Score>();
    }
    #endregion

    #region Methods

    public void AddScore(Score score)
    {
        this.scores.Add(score);
    }

    public List<Score> GetScores()
    {
        return this.scores;
    }

    #endregion
}