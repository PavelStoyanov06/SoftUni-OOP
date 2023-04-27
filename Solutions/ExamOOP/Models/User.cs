﻿using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        private double rating = 0;
        private bool isBlocked = false;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                lastName = value;
            }
        }

        public double Rating
        {
            get => rating;
            private set
            {
                rating = value;
            }
        }

        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked
        {
            get => isBlocked;
            private set => isBlocked = value;
        }

        public void DecreaseRating()
        {
            Rating -= 2.0;
            if(Rating < 0.0)
            {
                Rating = 0.0;
                IsBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            Rating += 0.5;
            if(Rating > 10.0)
            {
                Rating = 10.0;
            }
        }

        public override string ToString()
        {
            string result = $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";

            return result.TrimEnd();
        }
    }
}
