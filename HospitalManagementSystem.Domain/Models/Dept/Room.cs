namespace HospitalManagementSystem.Domain.Models.Department
{
    public class Room
    {
        public Guid Id { get; }
        public int Number { get; set; }
        public Guid? DepartmentId { get; private set; }
        public Guid? TagId { get; private set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Visit> Visits { get; set; } 
        public virtual Tag? Tag { get; set; }

        private void SetRoomNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Room number cannot be negative");
            }

            Number = number;
        }
        public void SetTag(Tag tag)
        {
            Tag = tag;
        }

        public Room(int number, Department d)
        {
            Id = Guid.NewGuid();
            try
            {
                Department = d;
                d.Rooms.Add(this);
                SetRoomNumber(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Room(int number)
        {
            Id = Guid.NewGuid();
            try
            {
                SetRoomNumber(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
