using System.Security.Cryptography.X509Certificates;

namespace FrontDeskApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorSetsNameAndCategory()
        {
            Hotel hotel = new Hotel("Sus", 4);

            string expectedName = "Sus";
            int expectedCategory = 4;
            int expectedTurnover = 0;

            Assert.That(hotel.FullName, Is.EqualTo(expectedName));
            Assert.That(hotel.Category, Is.EqualTo(expectedCategory));
            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
        }

        [Test]
        public void CtorNameAndCategroyThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(" ", 5));
            Assert.Throws<ArgumentException>(() => new Hotel("NewHotel", 6));
            Assert.Throws<ArgumentException>(() => new Hotel("NewHotel", 0));
        }

        [Test]
        public void AddRoomAddsCorrectly()
        {
            Hotel hotel = new Hotel("Small", 4);

            Room room = new Room(10, 12);

            int expectedRoomCount = 1;

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(expectedRoomCount));
        }

        [Test]
        public void BookRoom_ThrowsForAdults()
        {
            Hotel hotel = new Hotel("Nein", 4);
            Room room = new Room(7, 90);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 4, 50));
        }

        [Test]
        public void BookRoom_ThrowsForChildren()
        {
            Hotel hotel = new Hotel("Nein", 4);
            Room room = new Room(8, 4000);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -1, 4, 50));
        }

        [Test]
        public void BookRoom_ThrowsForResidenceDuration() 
        {
            Hotel hotel = new Hotel("Nein", 4);
            Room room = new Room(8, 5000);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, 0, 60));
        }

        [Test]
        public void BookRoom_NoBookingForNotEnoughBeds()
        {
            Hotel hotel = new Hotel("Sus", 5);
            Room room = new Room(3, 10000);

            hotel.AddRoom(room);

            Assert.That(hotel.Turnover.Equals(0));
        }

        [Test]
        public void BookRoom_NoBookingForLowBudget()
        {
            Hotel hotel = new Hotel("Sus", 5);
            Room room = new Room(3, 10000);
            hotel.AddRoom(room);

            hotel.BookRoom(1, 2, 3, 13000);
            int expectedTurnover = 0;

            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
        }

        [Test]
        public void BookRoom_WorksCorrectly()
        {
            Hotel hotel = new Hotel("Sus", 5);
            Room room = new Room(3, 10000);
            hotel.AddRoom(room);

            hotel.BookRoom(1, 2, 3, 50000);
            int expectedTurnover = 30000;

            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
        }
    }
}