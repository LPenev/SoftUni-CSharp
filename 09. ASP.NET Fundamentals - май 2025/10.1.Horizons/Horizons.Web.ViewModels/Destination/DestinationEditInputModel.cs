using System.ComponentModel.DataAnnotations;

namespace Horizons.Web.ViewModels.Destination;

public class DestinationEditInputModel : DestinationAddInputModel
{
    public int Id { get; set; }
    public string PublisherId { get; set; } = null!;
}
