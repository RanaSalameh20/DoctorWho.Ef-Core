using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

var _context =  new DoctorWhoCoreDbContext();

//CreateAuthor("sami");
//CreateCompanion("companion6", "Fedaa");
//CreateDoctor(66,"Doctor6" , new DateTime(1969, 3, 13),new DateTime(2012, 12, 25, 12, 33, 40), new DateTime(2015, 12, 25, 12, 33, 40));
//CreateEnemy("Feda'a" , "Black enemy");
//CreateEpisode(seriesNumber:1, 1, "NotRegular" , "The sky" , DateTime.Now , authorId:6 , null) ;

void CreateAuthor(string authorName)
{
    var author = new Author
    {
        AuthorName = authorName
    };

    _context.Authors.Add(author);
    _context.SaveChanges();
 
}

void CreateCompanion(string companionName , string whoPlayed)
{
    var companion = new Companion
    {
        CompanionName = companionName,
        WhoPlayed = whoPlayed
    };

    _context.Companions.Add(companion);
    _context.SaveChanges();
}

void CreateDoctor(int doctorNumber , string doctorName ,
    DateTime birthDate , DateTime firstEpisodeDate , DateTime lastEpisodeDate)
{
    var doctor = new Doctor
    {
        DoctorNumber = doctorNumber,
        DoctorName = doctorName,
        BirthDate = birthDate,
        FirstEpisodeDate = firstEpisodeDate,
        LastEpisodeDate = lastEpisodeDate,

        
    };
    _context.Doctors.Add(doctor);
    _context.SaveChanges();
}

void CreateEnemy(string enemyName, string description)
{
    var enemy = new Enemy
    {
        EnemyName = enemyName,
        Description = description,
    };

    _context.Enemies.Add(enemy);
    _context.SaveChanges();

    Console.WriteLine("Enemy created successfully.");
}
      
void CreateEpisode(int seriesNumber, int episodeNumber, string episodeType, 
                    string title, DateTime episodeDate, int authorId, int? doctorId)
{
    var author = GetAuthorById(authorId);
    if (author != null)
    {
        var episode = new Episode
        {
            SeriesNumber = seriesNumber,
            EpisodeNumber = episodeNumber,
            EpisodeType = episodeType,
            Title = title,
            EpisodeDate = episodeDate,
            Author = author
        };

        var doctor = GetDoctorById(doctorId);

        if (doctor != null)
        {
            episode.Doctor = doctor;
        }

        _context.Episodes.Add(episode);
        _context.SaveChanges();
    }

}
Author GetAuthorById(int authorId)
{
    var author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
    return author;
}

Doctor GetDoctorById(int? doctorId)
{
    if (doctorId.HasValue)
    {
        var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
        return doctor;
    }

    return null;
}

///////////////
void UpdateCompanion(int companionId , string newCompanionName)
{
    var companion = _context.Companions.FirstOrDefault(c => c.CompanionId == companionId);

    if (companion != null)
    {
        companion.CompanionName = newCompanionName;

    }
    _context.SaveChanges();
    Console.WriteLine("Companion updated successfully.");

}

void UpdateEnemy(int enemyId, string newEnemyName, string newDescription)
{
    var enemy = _context.Enemies.FirstOrDefault(e => e.EnemyId == enemyId);

    if (enemy != null)
    {
        enemy.EnemyName = newEnemyName;
        enemy.Description = newDescription;
    }

    _context.SaveChanges();
}

void UpdateAuthor(int authorId, string newAuthorName)
{
    var episode = new Episode()
    {
        SeriesNumber = 6,
        EpisodeNumber=  4,
        EpisodeType = "NotRegular",
        Title = "The moon",
        EpisodeDate = DateTime.Now,
    };
   
    var author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);

    if (author != null)
    {
        author.AuthorName = newAuthorName;
        author.Episodes.Add(episode);
    }

    _context.SaveChanges();
    Console.WriteLine("gone");
}

UpdateDoctor(3, "Doctor3", 2);
void UpdateDoctor(int doctorId, string newDoctorName, int episodeId)
{
    var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
    var episode = _context.Episodes.FirstOrDefault(e => e.EpisodeId == episodeId);

    if (doctor != null)
    {
        doctor.DoctorName = newDoctorName;
        //doctor.BirthDate = newBirthDate;
    }
    if(episode != null)
    {
        doctor.Episodes.Add(episode);
    }

    _context.SaveChanges();
}

void UpdateEpisode(int episodeId, string newEpisodeTitle, DateTime newEpisodeDate , int newAuthorId)
{
    var episode = _context.Episodes.FirstOrDefault(e => e.EpisodeId == episodeId);
    var author = _context.Authors.FirstOrDefault(a => a.AuthorId == newAuthorId);
   
    if (episode != null)
    {
        episode.Title = newEpisodeTitle;
        episode.EpisodeDate = newEpisodeDate;
    }
    if(author != null)
    {
        episode.Author = author;
    }
  

    _context.SaveChanges();
    Console.WriteLine("done");
}

////////////////////////

void DeleteDoctor(int doctorId)
{
    var doctor = _context.Doctors
        .Include(d => d.Episodes)
        .FirstOrDefault(d => d.DoctorId ==doctorId);
    if (doctor != null)
    {
        _context.Doctors.Remove(doctor);
    }
    //var state = _context.ChangeTracker.DebugView.ShortView;
    _context.SaveChanges();
}

void DeleteEnemy(int enemyId)
{
    var enemy = _context.Enemies
        .Include(e => e.Episodes)
        .FirstOrDefault(e => e.EnemyId == enemyId);

    if (enemy != null)
    {
        _context.Enemies.Remove(enemy);
    }

    _context.SaveChanges();
}

//DeleteCompanion() ------------to test after add companion
void DeleteCompanion(int companionId)
{
    var companion = _context.Companions
        
        .FirstOrDefault(c => c.CompanionId == companionId);

    if (companion != null)
    {
        _context.Companions.Remove(companion);
    }

    _context.SaveChanges();
}

void DeleteAuthor(int authorId)
{
    var author = _context.Authors
        .Include(a => a.Episodes)
        .FirstOrDefault(a => a.AuthorId == authorId);

    if (author != null)
    {
        _context.Authors.Remove(author);
    }

    _context.SaveChanges();
}

void DeleteEpisode(int episodeId)
{
    var episode = _context.Episodes.FirstOrDefault(e => e.EpisodeId == episodeId);

    if (episode != null)
    {
        _context.Episodes.Remove(episode);
    }

    _context.SaveChanges();
}

////////////////////////


//GetEpisodeForAuthor(2);
void GetEpisodeForAuthor(int authorId)
{
    var author = _context.Authors.Include(a => a.Episodes).
        FirstOrDefault(a => a.AuthorId == authorId);
    var episodes = author.Episodes.ToList();
    foreach ( var episode in episodes )
    {
        Console.WriteLine(episode.Title);
    }
}
//GetMostFrequentCompanions();
void GetMostFrequentCompanions()
{
    var companions = _context.FrequerntCompinaions
        .FromSqlRaw("EXEC spMostFrequentlyCompanion")
        .ToList();
}

//GetEnemies();
void GetEnemies()
{
    var episodeId = 5;
    var enemiesList = _context.Database.ExecuteSqlRaw("SELECT dbo.fnEnemies({0})", episodeId)
        .ToString();

   
}
