using System.ComponentModel.DataAnnotations;

namespace XE908.Models;

public class Controller
{
    [Key]
    public string HostName { get; set; }
    public string NormalizedHostName { get; set; }
    public ConferenceRoom ConferenceRoom { get; set; }
}