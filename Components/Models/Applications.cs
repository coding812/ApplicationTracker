using System.Reflection;
using SQLite;

namespace ApplicationsHelper;
public class Applications
{
    [PrimaryKey, AutoIncrement]
    public int ID {get; set;}
    public string? CompanyName {get; set;}
    public string? ContactName {get; set;}
    public DateTime? DateApplied {get; set;}
    public DateTime? FollowUp {get; set;}
    public string? PhoneNumber {get; set;}
    public string? Disposition {get; set;}
    public string? Notes {get; set;}

}
public class DatabaseHelper
{
    private SQLiteConnection db;

    public DatabaseHelper(string dbPath)
    {
        var directory = Path.GetDirectoryName(dbPath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Create the database file if it doesn't exist
        if (!File.Exists(dbPath))
        {
            File.Create(dbPath).Dispose();
        }

        db = new SQLiteConnection(dbPath);
        db.CreateTable<Applications>();
    }

    public void AddApplication(Applications application)
    {
        db.Insert(application);
    }

    public List<Applications> GetAllApplications()
    {
        return db.Table<Applications>().ToList();
    }

    public Applications GetApplicationById(int id)
    {
        return db.Find<Applications>(id);
    }

    public void UpdateApplication(Applications application)
    {
        db.Update(application);
    }

    public void DeleteApplication(int id)
    {
        db.Delete<Applications>(id);
    }
}


