
using EntityCRUD.Models;

namespace EntityCRUD.Data
{
    public class DataContext //: DbContext
    {
        public static List<Entity> entities = new List<Entity>()
        {
            new Entity()
            {
                Id = "1",
                Addresses = new List<Address>() 
                {
                    new Address() { City ="Bangalore", Country="India", AddressLine = " 1st cross Lalbagh Road"},
                    new Address() { City ="Bangalore", Country="India", AddressLine = " 1st cross MG Road"}
                },
                Dates = new List<DateClass> 
                { 
                    new DateClass() { Date = new DateTime(2000, 10, 2), DateType="StartDate"},
                    new DateClass() { Date = new DateTime(2020, 10, 2), DateType="EndDate"},
                },
                Gender="Male",
                Deceased=true,
                Names = new List<Name>()
                {
                    new Name() { FirstName="John", MiddleName= "Conner", Surname= "C"},
                    new Name() { FirstName="Johnny"}
                }
            },
            new Entity()
            {
                Id = "2",
                Addresses = new List<Address>()
                {
                    new Address() { City ="New York", Country="USA", AddressLine = "123 Main Street"},
                    new Address() { City ="Los Angeles", Country="USA", AddressLine = "456 Oak Avenue"}
                },
                Dates= new List<DateClass>()
                {
                    new DateClass() { Date = new DateTime(1980, 7, 8), DateType="StartDate"}
                },
                Gender="Female",
                Deceased=false,
                Names = new List<Name>()
                {
                    new Name() { FirstName="Alice", MiddleName= "Marie", Surname= "Doe"},
                    new Name() { FirstName="Alicia"}
                }
            },
            new Entity()
            {
                Id = "3",
                Addresses = new List<Address>()
                {
                    new Address() { City ="London", Country="UK", AddressLine = "789 High Street"},
                    new Address() { City ="Paris", Country="France", AddressLine = "101 Avenue des Champs-Élysées"}
                },
                Dates = new List<DateClass>
                {
                    new DateClass() { Date = new DateTime(1980, 7, 8), DateType="StartDate"},
                    new DateClass() { Date = new DateTime(2005, 12, 18), DateType="EndDate"},
                },
                Gender="Male",
                Deceased=true,
                Names = new List<Name>()
                {
                    new Name() { FirstName="Robert", MiddleName= "William", Surname= "Smith"},
                    new Name() { FirstName="Rob"}
                }
            },
            new Entity()
            {
                Id = "4",
                Addresses = new List<Address>()
                {
                    new Address() { City ="Berlin", Country="Germany", AddressLine = "456 Hauptstraße"},
                    new Address() { City ="Madrid", Country="Spain", AddressLine = "789 Calle Mayor"}
                },
                Dates = new List<DateClass>
                {
                    new DateClass() { Date = new DateTime(1995, 3, 15), DateType="StartDate"}
                },
                Gender="Female",
                Deceased=false,
                Names = new List<Name>()
                {
                    new Name() { FirstName="Maria", MiddleName= "Isabel", Surname= "Gonzalez"},
                    new Name() { FirstName="Mia"}
                }
            },

            new Entity()
            {
                Id = "5",
                Addresses = new List<Address>()
                {
                    new Address() { City ="Tokyo", Country="Japan", AddressLine = "123 Sakura Street"},
                    new Address() { City ="Seoul", Country="South Korea", AddressLine = "456 Gwanghwamun"}
                },
                Dates = new List<DateClass>
                {
                    new DateClass() { Date = new DateTime(1988, 11, 30), DateType="StartDate"}
                },
                Gender="Male",
                Deceased=false,
                Names = new List<Name>()
                {
                    new Name() { FirstName="Hiroshi", MiddleName= "Takahashi", Surname= "Yamamoto"},
                    new Name() { FirstName="Hiro"}
                }
            },
            new Entity()
            {
                Id = "6",
                Addresses = new List<Address>()
                {
                    new Address() { City ="Sydney", Country="Australia", AddressLine = "789 George Street"},
                    new Address() { City ="Auckland", Country="New Zealand", AddressLine = "101 Queen Street"}
                },
                Dates = new List<DateClass>
                {
                    new DateClass() { Date = new DateTime(2002, 5, 10), DateType="StartDate"},
                    new DateClass() { Date = new DateTime(2021, 9, 25), DateType="EndDate"},
                },
                Gender="Female",
                Deceased=false,
                Names = new List<Name>()
                {
                    new Name() { FirstName="Sophie", MiddleName= "Elizabeth", Surname= "Johnson"},
                    new Name() { FirstName="Soph"}
                }
            },
            new Entity()
            {
                Id = "7",
                Addresses = new List<Address>()
                {
                    new Address() { City ="Toronto", Country="Canada", AddressLine = "456 Yonge Street"},
                    new Address() { City ="Vancouver", Country="Canada", AddressLine = "789 Granville Street"}
                },
                Dates = new List<DateClass>(), // Empty list for individuals without an end date
                Gender="Male",
                Deceased=false,
                Names = new List<Name>()
                {
                    new Name() { FirstName="Daniel", MiddleName= "Thomas", Surname= "Brown"},
                    new Name() { FirstName="Dan"}
                }
            },
            new Entity()
            {
                Id = "8",
                Addresses = new List<Address>()
                {
                    new Address() { City ="Mexico City", Country="Mexico", AddressLine = "123 Reforma Avenue"},
                    new Address() { City ="Buenos Aires", Country="Argentina", AddressLine = "456 Avenida 9 de Julio"}
                },
                Dates = new List<DateClass>
                {
                    new DateClass() { Date = new DateTime(1990, 8, 20), DateType="StartDate"},
                    new DateClass() { Date = new DateTime(2022, 12, 5), DateType="EndDate"},
                },
                Gender="Female",
                Deceased=false,
                Names = new List<Name>()
                {
                    new Name() { FirstName="Isabella", MiddleName= "Maria", Surname= "Rodriguez"},
                    new Name() { FirstName="Isa"}
                }
            }
        };
    }
}
