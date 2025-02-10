using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XE908.Models;

public class ConferenceRoom
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(10)")]
    public string RoomNumber { get; set; }
    public string RoomDescription { get; set; }
    public int Capacity { get; set; }
    public string ControllerId { get; set; }
    public Controller Controller { get; set; }
    
}