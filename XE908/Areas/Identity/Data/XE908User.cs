using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XE908.Models;

namespace XE908.Areas.Identity.Data;

// Add profile data for application users by adding properties to the XE908User class
[Index("RFID_Batch", IsUnique = true)]
public class XE908User : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "varchar(256)")]
    public string FirstName { get; set; }
    [PersonalData]
    [Column(TypeName = "varchar(256)")]
    public string LastName { get; set; }
    [PersonalData]
    [Column(TypeName = "varchar(256)")]
    [Required]
    public string? RFID_Batch { get; set; }
    public List<Reservation> Reservations { get; set; }
}

