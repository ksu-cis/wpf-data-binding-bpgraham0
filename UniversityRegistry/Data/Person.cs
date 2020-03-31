using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace UniversityRegistry.Data
{
    /// <summary>
    /// A class representing a person associated with the university
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        /// <summary>
        /// Event triggered when properties of Person change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The next ID to assign to a newly-created person
        /// </summary>
        public static uint NextID = 80000000;

        /// <summary>
        /// The uinque identifier of this person
        /// </summary>
        public uint ID { get; private set; }

        string firstName;
        /// <summary>
        /// The person's first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName == value) return;
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        string lastName;
        /// <summary>
        /// The person's last name
        /// </summary>
        public string LastName {
            get { return lastName; }
            set
            {
                if (lastName == value) return;
                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        DateTime dateOfBirth;
        /// <summary>
        /// The person's date of birth
        /// </summary>
        public DateTime DateOfBirth {
            get { return dateOfBirth; }
            set
            {
                if (dateOfBirth == value) return;
                dateOfBirth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateOfBirth"));
            }
        }

        bool active;
        /// <summary>
        /// If this person is active in the university (currently a part of the university)
        /// </summary>
        public bool Active {
            get { return active; }
            set
            {
                if (active == value) return;
                active = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Active"));
            }

        }

        Role role;
        /// <summary>
        /// The person's role
        /// </summary>
        public Role Role {
            get { return role; }
            set
            {
                if (role == value) return;
                role = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Role"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isFaculty"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isUndergraduate"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isGraduate"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isStaff"));

            }
        }

        /// <summary>
        /// variable for if role is faculty
        /// </summary>
        public bool isFaculty
        {
            get { return Role == Role.Faculty; }
            set { Role = Role.Faculty; }
        }
        /// <summary>
        /// variable for if role is undergrad
        /// </summary>
        public bool isUndergraduate
        {
            get { return Role == Role.UndergraduateStudent; }
            set { Role = Role.UndergraduateStudent; }
        }
        /// <summary>
        /// variable for if role is graduate
        /// </summary>
        public bool isGraduate
        {
            get { return Role == Role.GraduateStudent; }
            set { Role = Role.GraduateStudent; }
        }
        /// <summary>
        /// variable for if role is staff
        /// </summary>
        public bool isStaff
        {
            get { return Role == Role.Staff; }
            set { Role = Role.Staff; }
        }

        /// <summary>
        /// Creates a new user, assigning them an ID
        /// </summary>
        public Person()
        {
            ID = NextID++;
        }

        /// <summary>
        /// Returns a string identifying the person
        /// </summary>
        /// <returns>A string consisting of last name, first name, and ID</returns>
        public override string ToString()
        {
            return $"{LastName}, {FirstName}, [{ID}]";
        }
    }
}
