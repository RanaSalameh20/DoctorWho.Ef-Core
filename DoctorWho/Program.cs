using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

var _context =  new DoctorWhoCoreDbContext();

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
void CreateEpisode(int seriesNumber, int episodeNumber, string episodeType,                    string title, DateTime episodeDate, int authorId, int? doctorId)
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
void UpdateDoctor(int doctorId, string newDoctorName, DateTime newBirthDate, int episodeId)
{
    var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
    var episode = _context.Episodes.FirstOrDefault(e => e.EpisodeId == episodeId);

    if (doctor != null)
    {
        doctor.DoctorName = newDoctorName;
        doctor.BirthDate = newBirthDate;
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

void AddEnemyToEpisode()
{
    var enemy1 = _context.Enemies.Find(1);
    var enemy2 = _context.Enemies.Find(2);
    var episode = _context.Episodes.Find(2);
    
    episode.Enemies.Add(enemy1);
    episode.Enemies.Add(enemy2);

    _context.SaveChanges();
}
void addCompanionToEpisode()
{
    var companion1 = _context.Companions.Find(4);
    var companion2 = _context.Companions.Find(5);
    var companion3 = _context.Companions.Find(6);
    var episode1 = _context.Episodes.Find(4);
    var episode2 = _context.Episodes.Find(5);
    
    episode1.Companions.Add(companion1);
    episode1.Companions.Add(companion2);
    episode1.Companions.Add(companion3);
    episode2.Companions.Add(companion1);

    _context.SaveChanges();
}
void GetAllDoctors()
{
    var doctors = _context.Doctors
        .Include(d => d.Episodes)
        .ToList();

    doctors.ForEach(d =>
    {
        Console.WriteLine(d.DoctorName + " has " + d.Episodes.Count + " Episodes.");
    });

}
void GetEnemy(int enemyId)
{
    var enemy = _context.Enemies
        .Include(e => e.Episodes)
        .FirstOrDefault(e => e.EnemyId == enemyId);
    if (enemy != null)
    {
        Console.WriteLine("EnemyId: " + enemy.EnemyId);
        Console.WriteLine("EnemyName: " + enemy.EnemyName);
        Console.WriteLine("Description: " + enemy.Description);
        Console.WriteLine("Episodes: " + enemy.Episodes.Count);
    }

}
void GetCompanion(int companionId)
{
    var companion = _context.Companions
        .Include(c => c.Episodes)
        .FirstOrDefault(c => c.CompanionId == companionId);
    var companionEpisodes = companion.Episodes.ToList();    
    if(companion != null)
    {
        Console.WriteLine(companion.CompanionName);
        Console.WriteLine(companion.WhoPlayed);
        companionEpisodes.ForEach(c => Console.WriteLine(c.Title));
    }

}