﻿using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models;

public class Song
{
    public Song()
    {
        this.SongPerformers = new HashSet<SongPerformer>();
    }

    public int Id { get; set; }


    [MaxLength(ValidationConstants.MaxLengthSongName)]
    public string Name { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    public DateTime CreatedOn { get; set; }

    public Genre Genre { get; set; }


    [ForeignKey(nameof(Album))]
    public int? AlbumId { get; set; }
    public Album? Album { get; set; }


    [ForeignKey(nameof(Writer))]
    public int WriterId { get; set; }
    public Writer Writer { get; set; } = null!;

    public decimal Price { get; set; }

    public ICollection<SongPerformer> SongPerformers { get; set; }
}
