using IAA.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAA.Business
{
    public class Person
    {

        public class PersonDTO
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string phone { get; set; }
            public string Address { get; set; }
            public string ImagePath { get; set; }
            public PersonDTO(int id, string firstName, string lastName, string email,
                    string phone, string address, string imagePath)
            {
                ID = id;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                this.phone = phone;
                Address = address;
                ImagePath = imagePath;
            }

        }

        public static List<PersonDTO> GetAllPeople()
        {
            List<PersonDataAccess.PersonEntity> personEntities = PersonDataAccess.getAllPeople();

            List<PersonDTO> personDTOs = new List<PersonDTO>();

            foreach (var student in personEntities)
            {
                personDTOs.Add(new PersonDTO(student.ID, student.FirstName, student.LastName,student.Email,student.phone,student.Address,student.ImagePath));
            }
            return personDTOs;

        }


        private void AddNewPerson(PersonDTO personDataObject)
        {
            //Mapping yapıp personEntity objesi oluşturup data access'e öyle göndermelisin.
            //Özellikle find yaparken 13 paramtere vermek zorunda kalmicaz
        }
    }
}
