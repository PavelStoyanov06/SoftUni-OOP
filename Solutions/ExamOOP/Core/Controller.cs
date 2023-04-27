using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            string result = string.Empty;

            if(routes.GetAll().Any(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length == length))
            {
                result = string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            else if(routes.GetAll().Any(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length < length))
            {
                result = string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }
            else
            {
                IRoute existingRoute = routes.GetAll().FirstOrDefault((x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length > length && x.IsLocked == false));

                if(existingRoute != null)
                {
                    existingRoute.LockRoute();
                }

                IRoute newRoute = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
                routes.AddModel(newRoute);
                result = string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
            }
            return result.TrimEnd();
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            string result = string.Empty;

            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);

            if(user.IsBlocked == true)
            {
                result = string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            else if(vehicle.IsDamaged == true)
            {
                result = string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            else if(route.IsLocked == true)
            {
                result = string.Format(OutputMessages.RouteLocked, routeId);
            }
            else
            {
                vehicle.Drive(route.Length);
                if (isAccidentHappened)
                {
                    vehicle.ChangeStatus();
                    user.DecreaseRating();
                }
                else
                {
                    user.IncreaseRating();
                }

                result = string.Format(vehicle.ToString());
            }

            return result.TrimEnd();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            string result = string.Empty;

            if (users.FindById(drivingLicenseNumber) != null)
            {
                result = string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            else
            {
                IUser user = new User(firstName, lastName, drivingLicenseNumber);

                users.AddModel(user);

                result = string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
            }
            return result.TrimEnd();
        }

        public string RepairVehicles(int count)
        {
            string result = string.Empty;

            var orderedVehicles = vehicles.GetAll().Where(x => x.IsDamaged == true).OrderBy(x => x.Brand).OrderBy(x => x.Model).ToList();


            if(orderedVehicles.Count > count)
            {
                for (int i = 0; i < count; i++)
                {
                    orderedVehicles[i].ChangeStatus();
                    orderedVehicles[i].Recharge();
                }
            }
            else
            {
                for (int i = 0; i < orderedVehicles.Count; i++)
                {
                    orderedVehicles[i].ChangeStatus();
                    orderedVehicles[i].Recharge();
                }
            }

            result = string.Format(OutputMessages.RepairedVehicles, count > orderedVehicles.Count ? count : orderedVehicles.Count);

            return result.TrimEnd();
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            string result = string.Empty;

            if(vehicleType != nameof(CargoVan) && vehicleType != nameof(PassengerCar))
            {
                result = string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            else if(vehicles.FindById(licensePlateNumber) != null)
            {
                result = string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            else
            {
                IVehicle vehicle;
                if(vehicleType == nameof(PassengerCar))
                {
                    vehicle = new PassengerCar(brand, model, licensePlateNumber);
                }
                else
                {
                    vehicle = new CargoVan(brand, model, licensePlateNumber);
                }

                vehicles.AddModel(vehicle);
                result = string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
            }

            return result.TrimEnd();
        }

        public string UsersReport()
        {
            var arrangedUsers = users.GetAll().OrderByDescending(x => x.Rating).OrderBy(x => x.LastName).OrderBy(x => x.FirstName).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in arrangedUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
