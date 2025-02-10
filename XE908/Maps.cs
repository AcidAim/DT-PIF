using XE908.Dtos.ConferenceRoomDto;
using XE908.Dtos.ReservationDto;
using XE908.Models;

namespace XE908;

public static class Maps
{
    public static Reservation ReservationDtoToReservation(this AddReservationDto reservationDto)
    {
        return new Reservation
        {
            ReservedOnTime = DateOnly.Parse(reservationDto.ReservedOnTime),
            ReservationStart = DateTime.Parse(reservationDto.ReservationStart),
            ReservationEnd = DateTime.Parse(reservationDto.ReservationEnd),
            ReservationPurpose = reservationDto.ReservationPurpose
        };
    }
    public static ConferenceRoom ConferenceRoomDtoToConferenceRoom(this AddConferenceRoomDto conferenceRoomDto)
    {
        return new ConferenceRoom
        {
            RoomNumber = conferenceRoomDto.RoomNumber,
            RoomDescription = conferenceRoomDto.RoomDescription,
            Capacity = conferenceRoomDto.Capacity,
            ControllerId = conferenceRoomDto.ControllerId,
            Controller = conferenceRoomDto.Controller
        };
    }
}