using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorCapacitySetCorrectly()
        {
            Garage garage = new Garage(10);
            int expectedCap = 10;
            Assert.That(garage.Capacity, Is.EqualTo(expectedCap));
        }

        [Test]
        public void CtorAreVehiclesSetCorrectly()
        {
            Garage garage = new Garage(10);

            int expectedVehicleCount = 0;

            Assert.That(garage.Vehicles.Count, Is.EqualTo(expectedVehicleCount));
        }

        [Test]
        public void AddVehicleReturnsFalseOnSameCount()
        {
            Garage garage = new Garage(1);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);
            Vehicle vehicle1 = new Vehicle("non", "sus", "GGGFsf#", 54.6);

            garage.AddVehicle(vehicle);

            bool actualRes = garage.AddVehicle(vehicle1);

            Assert.That(actualRes, Is.False);
        }

        [Test]
        public void AddVehicleFalseWhenSameLicensePlate()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);
            Vehicle vehicle1 = new Vehicle("non", "sus", "GGGFG%#", 54.6);

            garage.AddVehicle(vehicle);
            bool actualRes = garage.AddVehicle(vehicle1);

            Assert.That(actualRes, Is.False);
        }

        [Test]
        public void AddVehicleAddsVehicleCorrectly()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);

            bool messageRes = garage.AddVehicle(vehicle);

            int expectedRes = 1;

            Assert.That(garage.Vehicles.Count, Is.EqualTo(expectedRes));
            Assert.That(messageRes, Is.True);
        }

        [Test]
        public void VehicleCannotDrive()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);

            garage.AddVehicle(vehicle);

            Assert.That(() => garage.DriveVehicle("GGGFG%#", 150, false), Throws.Nothing);
            garage.DriveVehicle("GGGFG%#", 30, false);
            Assert.That(() => garage.DriveVehicle("GGGFG%#", 100, false), Throws.Nothing);
            garage.DriveVehicle("GGGFG%#", 30, true);
            Assert.That(() => garage.DriveVehicle("GGGFG%#", 20, true), Throws.Nothing);
        }

        [Test]
        public void VehicleCanDrive()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);

            garage.AddVehicle(vehicle);

            garage.DriveVehicle("GGGFG%#", 20, true);

            int expectedBatteryLevel = 80;

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(expectedBatteryLevel));
            Assert.That(vehicle.IsDamaged, Is.True);
        }

        [Test]
        public void TestRepairing()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);

            garage.AddVehicle(vehicle);

            garage.DriveVehicle("GGGFG%#", 20, true);

            string actualOut = garage.RepairVehicles();

            string expectedOut = "Vehicles repaired: 1";

            Assert.That(actualOut, Is.EqualTo(expectedOut));
            Assert.That(vehicle.IsDamaged, Is.False);
        }

        [Test]
        public void TestChargingWorking()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);

            garage.AddVehicle(vehicle);

            garage.DriveVehicle("GGGFG%#", 20, false);

            int actualOut = garage.ChargeVehicles(100);

            int expectedOut = 1;

            Assert.That(actualOut, Is.EqualTo(expectedOut));
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
        }

        [Test]
        public void TestChargingNotWorking()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("non", "sus", "GGGFG%#", 54.6);

            garage.AddVehicle(vehicle);

            garage.DriveVehicle("GGGFG%#", 20, false);

            int actualOut = garage.ChargeVehicles(40);

            int expectedOut = 0;

            Assert.That(actualOut, Is.EqualTo(expectedOut));
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(80));
        }
    }
}