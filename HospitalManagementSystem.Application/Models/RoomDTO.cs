using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Application.Models
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid? tagId { get; set; }
        public RoomDTO(Room room)
        {
            this.Id = room.Id;
            this.Number = room.Number;
            this.tagId = room.TagId;
        }
    }
}
