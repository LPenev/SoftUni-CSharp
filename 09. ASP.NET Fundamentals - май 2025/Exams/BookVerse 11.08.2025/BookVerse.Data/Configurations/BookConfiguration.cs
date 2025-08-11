using BookVerse.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> b)
    {
        b.HasKey(x => x.Id);

        b.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(TitleMaxLength);

        b.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(DescriptionMaxLength);

        b.Property(x => x.CoverImageUrl)
            .HasMaxLength(CoverImageUrlMaxLength);

        b.Property(x => x.PublisherId)
            .IsRequired();

        b.Property(x => x.PublishedOn)
            .IsRequired()
            .HasColumnType("date");

        b.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        b.HasOne(x => x.Publisher)
            .WithMany()
            .HasForeignKey(x => x.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasQueryFilter(book => !book.IsDeleted);
    }
}

